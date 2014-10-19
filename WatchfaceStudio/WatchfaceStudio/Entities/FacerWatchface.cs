using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WatchfaceStudio.Entities
{
    public class FacerWatchface
    {
        public bool Changed;
        public Forms.WatchfaceEditorForm EditorForm;
        public FacerLayer SelectedLayer;

        // Project data
        public readonly FacerWatchfaceDescription Description;
        public Image PreviewImage;
        public readonly Dictionary<string, Image> Images;
        public readonly Dictionary<string, FacerCustomFont> CustomFonts;
        public readonly List<FacerLayer> Layers;

        private Image _badImage;

        public Image BadImage
        {
            get
            {
                if (_badImage == null)
                {
                    var bmp = new Bitmap(100, 100);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                        g.DrawLine(Pens.Red, 0, 0, 99, 99);
                        g.DrawLine(Pens.Red, 0, 99, 99, 0);
                        g.DrawString("BAD\nIMAGE", new Font("Arial", 12), Brushes.Black, 5, 5);
                    }
                    _badImage = bmp;
                }
                return _badImage;
            }
        }

        public string AddImageFile(string imageFile)
        {
            var key = Path.GetFileName(imageFile) ?? string.Empty;
            var i = 0;
            while (Images.ContainsKey(key))
                key = string.Concat(Path.GetFileName(imageFile), "(", i++, ")");
            try
            {
                Images.Add(key, Image.FromFile(imageFile));
            }
            catch
            {
                Images.Add(key, BadImage);
            }
            return key;
        }

        public string AddFontFile(string fontFile)
        {
            var key = Path.GetFileName(fontFile) ?? string.Empty;
            var i = 0;
            while (CustomFonts.ContainsKey(key))
                key = string.Concat(Path.GetFileName(fontFile), "(", i++, ")");
            CustomFonts.Add(key, new FacerCustomFont(fontFile));
            return key;
        }

        public FacerWatchface(string folder)
        {
            if (folder != null)
            {
                var lookForWatchface = Directory.EnumerateFiles(folder, "watchface.json", SearchOption.AllDirectories).ToList();
                if (!lookForWatchface.Any())
                    throw new Exception("watchface.json was not found");

                var watchfaceFile = lookForWatchface.First();
                var foundFolder = Path.GetDirectoryName(watchfaceFile);
                if (foundFolder != null && foundFolder != folder)
                {
                    folder = foundFolder;
                }

                var jsonString = File.ReadAllText(watchfaceFile);
                Layers = JsonConvert.DeserializeObject<List<FacerLayer>>(jsonString, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Error });

                var descriptionFile = Path.Combine(folder, "description.json");
                if (!File.Exists(descriptionFile))
                    throw new Exception("description.json was not found");
                jsonString = File.ReadAllText(descriptionFile);
                Description = JsonConvert.DeserializeObject<FacerWatchfaceDescription>(jsonString, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Error });

                PreviewImage = Image.FromFile(Path.Combine(folder, "preview.png"));

                Images = new Dictionary<string, Image>();
                var imagesFolder = Path.Combine(folder, "images");
                var imageExtensions = new[] {".jpg", ".jpeg", ".bmp", ".gif", ".png", "."};
                if (Directory.Exists(imagesFolder))
                    foreach (var imageFile in 
                        Directory.EnumerateFiles(imagesFolder)
                        .Where(x => imageExtensions.Any(f => f==Path.GetExtension(x))))
                    {
                        AddImageFile(imageFile);
                    }
                CustomFonts = new Dictionary<string, FacerCustomFont>();
                var fontsFolder = Path.Combine(folder, "fonts");
                if (Directory.Exists(fontsFolder))
                    foreach (var fontFile in Directory.EnumerateFiles(fontsFolder, "*.ttf"))
                    {
                        AddFontFile(fontFile);
                    }
            }
            else
            {
                Layers = new List<FacerLayer>();
                Description = new FacerWatchfaceDescription { 
                    title = "Untitled",
                    id = Guid.NewGuid().ToString("N").ToLower() };
                Images = new Dictionary<string, Image>();
                CustomFonts = new Dictionary<string, FacerCustomFont>();
            }
        }

        internal bool SaveTo(string folderPath)
        {
            bool errorsFound;
            string firstErrorMessage = null;
            try
            {
                var preview = FacerWatcfaceRenderer.Render(this, WatchType.Current, out errorsFound, out firstErrorMessage);

                var watchfileContent = JsonConvert.SerializeObject(Layers, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                File.WriteAllText(Path.Combine(folderPath, "watchface.json"), watchfileContent);

                var descriptionContent = JsonConvert.SerializeObject(Description, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                File.WriteAllText(Path.Combine(folderPath, "description.json"), descriptionContent);

                var savedSelectedLayer = SelectedLayer;
                SelectedLayer = null;

                SelectedLayer = savedSelectedLayer;
                preview.Save(Path.Combine(folderPath, "preview.png"), System.Drawing.Imaging.ImageFormat.Png);

                if (CustomFonts.Count > 0)
                {
                    Directory.CreateDirectory(Path.Combine(folderPath, "fonts"));
                    foreach (var kvp in CustomFonts)
                    {
                        File.WriteAllBytes(Path.Combine(folderPath, "fonts", kvp.Key), kvp.Value.FileBytes);
                    }
                }

                if (Images.Count > 0)
                {
                    Directory.CreateDirectory(Path.Combine(folderPath, "images"));
                    foreach (var kvp in Images)
                    {
                        kvp.Value.Save(Path.Combine(folderPath, "images", kvp.Key), System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
            catch (Exception ex)
            {
                errorsFound = true;
                #if DEBUG
                    MessageBox.Show(ex.Message  + ex.StackTrace + (ex.InnerException != null ? ex.InnerException.Message + ex.InnerException.StackTrace : string.Empty)
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                #endif
            }
            if (errorsFound)
                throw new Exception(firstErrorMessage);
            return errorsFound;
        }
    }
}
