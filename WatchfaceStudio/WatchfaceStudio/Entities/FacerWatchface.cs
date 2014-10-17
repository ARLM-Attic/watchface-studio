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

namespace WatchfaceStudio.Entities
{
    public class FacerWatchface
    {
        public bool Changed;
        public Forms.WatchfaceEditorForm EditorForm;

        public FacerWatchfaceDescription Description;
        public Image PreviewImage;
        public Dictionary<string, Image> Images;
        public Dictionary<string, byte[]> FontFiles;
        public FacerLayer SelectedLayer;

        public static Dictionary<FacerFont, Tuple<PrivateFontCollection, FontStyle>> FacerFontConfig;
        
        private PrivateFontCollection _customFonts;
        public Dictionary<string, FontFamily> CustomFonts;
        public List<FacerLayer> Layers;

        private static PrivateFontCollection PFCWithFont(int index)
        {
            var col = new PrivateFontCollection();
            switch (index)
            {
                case 0: col.AddFontFile("Fonts/Roboto-Black.ttf"); break;
                case 1: col.AddFontFile("Fonts/Roboto-Bold.ttf"); break;
                case 2: col.AddFontFile("Fonts/Roboto-BoldItalic.ttf"); break;
                case 3: col.AddFontFile("Fonts/RobotoCondensed-Bold.ttf"); break;
                case 4: col.AddFontFile("Fonts/RobotoCondensed-BoldItalic.ttf"); break;
                case 5: col.AddFontFile("Fonts/RobotoCondensed-Italic.ttf"); break;
                case 6: col.AddFontFile("Fonts/RobotoCondensed-Light.ttf"); break;
                case 7: col.AddFontFile("Fonts/RobotoCondensed-LightItalic.ttf"); break;
                case 8: col.AddFontFile("Fonts/RobotoCondensed-Regular.ttf"); break;
                case 9: col.AddFontFile("Fonts/Roboto-Italic.ttf"); break;
                case 10: col.AddFontFile("Fonts/Roboto-Light.ttf"); break;
                case 11: col.AddFontFile("Fonts/Roboto-LightItalic.ttf"); break;
                case 12: col.AddFontFile("Fonts/Roboto-Medium.ttf"); break;
                case 13: col.AddFontFile("Fonts/Roboto-MediumItalic.ttf"); break;
                case 14: col.AddFontFile("Fonts/Roboto-Regular.ttf"); break;
                case 15: col.AddFontFile("Fonts/RobotoSlab-Bold.ttf"); break;
                case 16: col.AddFontFile("Fonts/RobotoSlab-Light.ttf"); break;
                case 17: col.AddFontFile("Fonts/RobotoSlab-Regular.ttf"); break;
                case 18: col.AddFontFile("Fonts/RobotoSlab-Thin.ttf"); break;
                case 19: col.AddFontFile("Fonts/Roboto-Thin.ttf"); break;
                case 20: col.AddFontFile("Fonts/Roboto-ThinItalic.ttf"); break;
            }
            return col;
        }

        static FacerWatchface()
        {
            //_facerFonts = new PrivateFontCollection();
            
            
            
            //0 - Roboto
            //1 - Roboto Cond
            //2 - Roboto Slab
            /*
            FacerFontConfig = new Dictionary<FacerFont, Tuple<FontFamily, FontStyle>>();

            FacerFontConfig.Add(FacerFont.RobotoThin, new Tuple<FontFamily, FontStyle>(_facerFonts.Families[0], FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLight, new Tuple<FontFamily, FontStyle>(_facerFonts.Families[0], FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLightCondensed, new Tuple<FontFamily, FontStyle>(_facerFonts.Families[1], FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.Roboto, new Tuple<FontFamily, FontStyle>(_facerFonts.Families[0], FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoBlack, new Tuple<FontFamily, FontStyle>(_facerFonts.Families[0], FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoCondensed, new Tuple<FontFamily, FontStyle>(_facerFonts.Families[1], FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabThin, new Tuple<FontFamily, FontStyle>(_facerFonts.Families[2], FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabLight, new Tuple<FontFamily, FontStyle>(_facerFonts.Families[2], FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlab, new Tuple<FontFamily, FontStyle>(_facerFonts.Families[2], FontStyle.Regular));
            */
            FacerFontConfig = new Dictionary<FacerFont, Tuple<PrivateFontCollection, FontStyle>>();

            FacerFontConfig.Add(FacerFont.RobotoThin, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(0), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLight, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(10), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLightCondensed, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(6), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.Roboto, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(14), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoBlack, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(0), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoCondensed, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(8), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabThin, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(18), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabLight, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(16), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlab, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(17), FontStyle.Regular));

            FacerFontConfig.Add(FacerFont.RobotoThin_Bold, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(19), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoLight_Bold, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(10), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoLightCondensed_Bold, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(6), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.Roboto_Bold, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(1), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoBlack_Bold, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(0), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoCondensed_Bold, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(3), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabThin_Bold, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(18), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoSlabLight_Bold, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(16), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoSlab_Bold, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(15), FontStyle.Regular));

            FacerFontConfig.Add(FacerFont.RobotoThin_Italic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(20), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLight_Italic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(11), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLightCondensed_Italic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(7), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.Roboto_Italic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(9), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoBlack_Italic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(0), FontStyle.Italic));//needs italic
            FacerFontConfig.Add(FacerFont.RobotoCondensed_Italic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(5), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabThin_Italic , new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(18), FontStyle.Italic));//needs italic
            FacerFontConfig.Add(FacerFont.RobotoSlabLight_Italic , new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(16), FontStyle.Italic));//needs italic
            FacerFontConfig.Add(FacerFont.RobotoSlab_Italic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(17), FontStyle.Italic));//needs italic

            FacerFontConfig.Add(FacerFont.RobotoThin_BoldItalic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(20), FontStyle.Bold));//needs bold
            FacerFontConfig.Add(FacerFont.RobotoLight_BoldItalic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(11), FontStyle.Bold));//needs bold
            FacerFontConfig.Add(FacerFont.RobotoLightCondensed_BoldItalic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(7), FontStyle.Bold));//needs bold
            FacerFontConfig.Add(FacerFont.Roboto_BoldItalic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(2), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoBlack_BoldItalic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(0), FontStyle.Bold | FontStyle.Italic));//needs bold & italic
            FacerFontConfig.Add(FacerFont.RobotoCondensed_BoldItalic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(4), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabThin_BoldItalic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(18), FontStyle.Bold | FontStyle.Italic));//needs bold & italic
            FacerFontConfig.Add(FacerFont.RobotoSlabLight_BoldItalic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(16), FontStyle.Bold | FontStyle.Italic));//needs bold & italic
            FacerFontConfig.Add(FacerFont.RobotoSlab_BoldItalic, new Tuple<PrivateFontCollection,FontStyle>(PFCWithFont(15), FontStyle.Bold | FontStyle.Italic));//needs italic
    
        }

        public void AddImageFile(string imageFile)
        {
            Images.Add(Path.GetFileNameWithoutExtension(imageFile), Image.FromFile(imageFile));
        }

        public void AddFontFile(string fontFile)
        {
            _customFonts.AddFontFile(fontFile);
            CustomFonts.Add(Path.GetFileName(fontFile), _customFonts.Families.Last());
            FontFiles.Add(Path.GetFileName(fontFile), File.ReadAllBytes(fontFile));
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
                _customFonts = new PrivateFontCollection();
                CustomFonts = new Dictionary<string, FontFamily>();
                FontFiles = new Dictionary<string, byte[]>();
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
                _customFonts = new PrivateFontCollection();
                CustomFonts = new Dictionary<string, FontFamily>();
                FontFiles = new Dictionary<string, byte[]>();
            }
        }

        internal void SaveTo(string folderPath)
        {
            var watchfileContent = JsonConvert.SerializeObject(Layers, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            File.WriteAllText(Path.Combine(folderPath, "watchface.json"), watchfileContent);

            var descriptionContent = JsonConvert.SerializeObject(Description, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            File.WriteAllText(Path.Combine(folderPath, "description.json"), descriptionContent);

            var savedSelectedLayer = SelectedLayer;
            SelectedLayer = null;
            var preview = FacerWatcfaceRenderer.Render(this, ((StudioForm)EditorForm.MdiParent).Watchtype);
            SelectedLayer = savedSelectedLayer;
            preview.Save(Path.Combine(folderPath, "preview.png"), System.Drawing.Imaging.ImageFormat.Png);

            if (FontFiles.Count > 0)
            {
                Directory.CreateDirectory(Path.Combine(folderPath, "fonts"));
                foreach (var kvp in FontFiles)
                {
                    File.WriteAllBytes(Path.Combine(folderPath, "fonts", kvp.Key), kvp.Value);
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
    }
}
