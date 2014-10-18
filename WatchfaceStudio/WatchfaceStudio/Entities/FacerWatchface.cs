using ExpressionEvaluator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WatchfaceStudio.Entities
{
    public class FacerWatchface
    {
        public bool Changed;
        public Forms.WatchfaceEditorForm EditorForm;
        public FacerLayer SelectedLayer;

        // Project data
        public FacerWatchfaceDescription Description;
        public Image PreviewImage;
        public Dictionary<string, Image> Images;
        public Dictionary<string, FacerCustomFont> CustomFonts;
        public List<FacerLayer> Layers;

        public string AddImageFile(string imageFile)
        {
            var key = Path.GetFileNameWithoutExtension(imageFile);
            var i = 0;
            while (Images.ContainsKey(key))
                key = string.Concat(Path.GetFileNameWithoutExtension(imageFile), "(", i++, ")");
            Images.Add(key, Image.FromFile(imageFile));
            return key;
        }

        public string AddFontFile(string fontFile)
        {
            var key = Path.GetFileName(fontFile);
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
                var lookForWatchface = Directory.EnumerateFiles(folder, "watchface.json", SearchOption.AllDirectories);
                if (lookForWatchface.Count() == 0)
                    throw new Exception("watchface.json was not found");

                var watchfaceFile = lookForWatchface.First();
                var foundFolder = Path.GetDirectoryName(watchfaceFile);
                if (foundFolder != folder)
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

                Images = new Dictionary<string, Image>();
                var imagesFolder = Path.Combine(folder, "images");
                if (Directory.Exists(imagesFolder))
                    foreach (var imageFile in Directory.EnumerateFiles(imagesFolder, "*."))
                    {
                        AddImageFile(imageFile);
                    }
                CustomFonts = new Dictionary<string, FacerCustomFont>();
                var fontsFolder = Path.Combine(folder, "fonts");
                if (Directory.Exists(fontsFolder))
                    foreach (var fontFile in Directory.EnumerateFiles(fontsFolder, "*.*"))
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
            try
            {
                var preview = FacerWatcfaceRenderer.Render(this, WatchType.Current, out errorsFound);

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
            return errorsFound;
        }
    }
}
