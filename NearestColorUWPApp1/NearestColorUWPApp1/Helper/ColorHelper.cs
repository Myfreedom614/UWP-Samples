using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NearestColorUWPApp1.Helper
{
    public class ColorHelper
    {
        public static Vector3 GetSystemDrawingColorFromHexString(string hexString)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(hexString, @"[#]([0-9]|[a-f]|[A-F]){6}\b"))
                throw new ArgumentException();
            int red = int.Parse(hexString.Substring(1, 2), NumberStyles.HexNumber);
            int green = int.Parse(hexString.Substring(3, 2), NumberStyles.HexNumber);
            int blue = int.Parse(hexString.Substring(5, 2), NumberStyles.HexNumber);
            return new Vector3(red, green, blue);
        }

        public static string GetNearestColorName(Vector3 vect)
        {
            var cr = GetClosestColor(GetColorReferences(), vect);
            if( cr != null )
            {
                return cr.Name;
            }
            else
                return string.Empty;
        }

        private static ColorReference GetClosestColor(ColorReference[] colorReferences, Vector3 currentColor)
        {
            ColorReference tMin = null;
            float minDist = float.PositiveInfinity;

            foreach (ColorReference t in colorReferences)
            {
                float dist = Vector3.Distance(t.Argb, currentColor);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            return tMin;
        }

        private static ColorReference[] GetColorReferences()
        {
            return new ColorReference[] {
                new ColorReference() { Name="AliceBlue", Argb=new Vector3 (240,248,255) },
new ColorReference() { Name="LightSalmon", Argb=new Vector3 (255,160,122) },
new ColorReference() { Name="AntiqueWhite", Argb=new Vector3 (250,235,215) },
new ColorReference() { Name="LightSeaGreen", Argb=new Vector3 (32,178,170) },
new ColorReference() { Name="Aqua", Argb=new Vector3 (0,255,255) },
new ColorReference() { Name="LightSkyBlue", Argb=new Vector3 (135,206,250) },
new ColorReference() { Name="Aquamarine", Argb=new Vector3 (127,255,212) },
new ColorReference() { Name="LightSlateGray", Argb=new Vector3 (119,136,153) },
new ColorReference() { Name="Azure", Argb=new Vector3 (240,255,255) },
new ColorReference() { Name="LightSteelBlue", Argb=new Vector3 (176,196,222) },
new ColorReference() { Name="Beige", Argb=new Vector3 (245,245,220) },
new ColorReference() { Name="LightYellow", Argb=new Vector3 (255,255,224) },
new ColorReference() { Name="Bisque", Argb=new Vector3 (255,228,196) },
new ColorReference() { Name="Lime", Argb=new Vector3 (0,255,0) },
new ColorReference() { Name="Black", Argb=new Vector3 (0,0,0) },
new ColorReference() { Name="LimeGreen", Argb=new Vector3 (50,205,50) },
new ColorReference() { Name="BlanchedAlmond", Argb=new Vector3 (255,255,205) },
new ColorReference() { Name="Linen", Argb=new Vector3 (250,240,230) },
new ColorReference() { Name="Blue", Argb=new Vector3 (0,0,255) },
new ColorReference() { Name="Magenta", Argb=new Vector3 (255,0,255) },
new ColorReference() { Name="BlueViolet", Argb=new Vector3 (138,43,226) },
new ColorReference() { Name="Maroon", Argb=new Vector3 (128,0,0) },
new ColorReference() { Name="Brown", Argb=new Vector3 (165,42,42) },
new ColorReference() { Name="MediumAquamarine", Argb=new Vector3 (102,205,170) },
new ColorReference() { Name="BurlyWood", Argb=new Vector3 (222,184,135) },
new ColorReference() { Name="MediumBlue", Argb=new Vector3 (0,0,205) },
new ColorReference() { Name="CadetBlue", Argb=new Vector3 (95,158,160) },
new ColorReference() { Name="MediumOrchid", Argb=new Vector3 (186,85,211) },
new ColorReference() { Name="Chartreuse", Argb=new Vector3 (127,255,0) },
new ColorReference() { Name="MediumPurple", Argb=new Vector3 (147,112,219) },
new ColorReference() { Name="Chocolate", Argb=new Vector3 (210,105,30) },
new ColorReference() { Name="MediumSeaGreen", Argb=new Vector3 (60,179,113) },
new ColorReference() { Name="Coral", Argb=new Vector3 (255,127,80) },
new ColorReference() { Name="MediumSlateBlue", Argb=new Vector3 (123,104,238) },
new ColorReference() { Name="CornflowerBlue", Argb=new Vector3 (100,149,237) },
new ColorReference() { Name="MediumSpringGreen", Argb=new Vector3 (0,250,154) },
new ColorReference() { Name="Cornsilk", Argb=new Vector3 (255,248,220) },
new ColorReference() { Name="MediumTurquoise", Argb=new Vector3 (72,209,204) },
new ColorReference() { Name="Crimson", Argb=new Vector3 (220,20,60) },
new ColorReference() { Name="MediumVioletRed", Argb=new Vector3 (199,21,112) },
new ColorReference() { Name="Cyan", Argb=new Vector3 (0,255,255) },
new ColorReference() { Name="MidnightBlue", Argb=new Vector3 (25,25,112) },
new ColorReference() { Name="DarkBlue", Argb=new Vector3 (0,0,139) },
new ColorReference() { Name="MintCream", Argb=new Vector3 (245,255,250) },
new ColorReference() { Name="DarkCyan", Argb=new Vector3 (0,139,139) },
new ColorReference() { Name="MistyRose", Argb=new Vector3 (255,228,225) },
new ColorReference() { Name="DarkGoldenrod", Argb=new Vector3 (184,134,11) },
new ColorReference() { Name="Moccasin", Argb=new Vector3 (255,228,181) },
new ColorReference() { Name="DarkGray", Argb=new Vector3 (169,169,169) },
new ColorReference() { Name="NavajoWhite", Argb=new Vector3 (255,222,173) },
new ColorReference() { Name="DarkGreen", Argb=new Vector3 (0,100,0) },
new ColorReference() { Name="Navy", Argb=new Vector3 (0,0,128) },
new ColorReference() { Name="DarkKhaki", Argb=new Vector3 (189,183,107) },
new ColorReference() { Name="OldLace", Argb=new Vector3 (253,245,230) },
new ColorReference() { Name="DarkMagena", Argb=new Vector3 (139,0,139) },
new ColorReference() { Name="Olive", Argb=new Vector3 (128,128,0) },
new ColorReference() { Name="DarkOliveGreen", Argb=new Vector3 (85,107,47) },
new ColorReference() { Name="OliveDrab", Argb=new Vector3 (107,142,45) },
new ColorReference() { Name="DarkOrange", Argb=new Vector3 (255,140,0) },
new ColorReference() { Name="Orange", Argb=new Vector3 (255,165,0) },
new ColorReference() { Name="DarkOrchid", Argb=new Vector3 (153,50,204) },
new ColorReference() { Name="OrangeRed", Argb=new Vector3 (255,69,0) },
new ColorReference() { Name="DarkRed", Argb=new Vector3 (139,0,0) },
new ColorReference() { Name="Orchid", Argb=new Vector3 (218,112,214) },
new ColorReference() { Name="DarkSalmon", Argb=new Vector3 (233,150,122) },
new ColorReference() { Name="PaleGoldenrod", Argb=new Vector3 (238,232,170) },
new ColorReference() { Name="DarkSeaGreen", Argb=new Vector3 (143,188,143) },
new ColorReference() { Name="PaleGreen", Argb=new Vector3 (152,251,152) },
new ColorReference() { Name="DarkSlateBlue", Argb=new Vector3 (72,61,139) },
new ColorReference() { Name="PaleTurquoise", Argb=new Vector3 (175,238,238) },
new ColorReference() { Name="DarkSlateGray", Argb=new Vector3 (40,79,79) },
new ColorReference() { Name="PaleVioletRed", Argb=new Vector3 (219,112,147) },
new ColorReference() { Name="DarkTurquoise", Argb=new Vector3 (0,206,209) },
new ColorReference() { Name="PapayaWhip", Argb=new Vector3 (255,239,213) },
new ColorReference() { Name="DarkViolet", Argb=new Vector3 (148,0,211) },
new ColorReference() { Name="PeachPuff", Argb=new Vector3 (255,218,155) },
new ColorReference() { Name="DeepPink", Argb=new Vector3 (255,20,147) },
new ColorReference() { Name="Peru", Argb=new Vector3 (205,133,63) },
new ColorReference() { Name="DeepSkyBlue", Argb=new Vector3 (0,191,255) },
new ColorReference() { Name="Pink", Argb=new Vector3 (255,192,203) },
new ColorReference() { Name="DimGray", Argb=new Vector3 (105,105,105) },
new ColorReference() { Name="Plum", Argb=new Vector3 (221,160,221) },
new ColorReference() { Name="DodgerBlue", Argb=new Vector3 (30,144,255) },
new ColorReference() { Name="PowderBlue", Argb=new Vector3 (176,224,230) },
new ColorReference() { Name="Firebrick", Argb=new Vector3 (178,34,34) },
new ColorReference() { Name="Purple", Argb=new Vector3 (128,0,128) },
new ColorReference() { Name="FloralWhite", Argb=new Vector3 (255,250,240) },
new ColorReference() { Name="Red", Argb=new Vector3 (255,0,0) },
new ColorReference() { Name="ForestGreen", Argb=new Vector3 (34,139,34) },
new ColorReference() { Name="RosyBrown", Argb=new Vector3 (188,143,143) },
new ColorReference() { Name="Fuschia", Argb=new Vector3 (255,0,255) },
new ColorReference() { Name="RoyalBlue", Argb=new Vector3 (65,105,225) },
new ColorReference() { Name="Gainsboro", Argb=new Vector3 (220,220,220) },
new ColorReference() { Name="SaddleBrown", Argb=new Vector3 (139,69,19) },
new ColorReference() { Name="GhostWhite", Argb=new Vector3 (248,248,255) },
new ColorReference() { Name="Salmon", Argb=new Vector3 (250,128,114) },
new ColorReference() { Name="Gold", Argb=new Vector3 (255,215,0) },
new ColorReference() { Name="SandyBrown", Argb=new Vector3 (244,164,96) },
new ColorReference() { Name="Goldenrod", Argb=new Vector3 (218,165,32) },
new ColorReference() { Name="SeaGreen", Argb=new Vector3 (46,139,87) },
new ColorReference() { Name="Gray", Argb=new Vector3 (128,128,128) },
new ColorReference() { Name="Seashell", Argb=new Vector3 (255,245,238) },
new ColorReference() { Name="Green", Argb=new Vector3 (0,128,0) },
new ColorReference() { Name="Sienna", Argb=new Vector3 (160,82,45) },
new ColorReference() { Name="GreenYellow", Argb=new Vector3 (173,255,47) },
new ColorReference() { Name="Silver", Argb=new Vector3 (192,192,192) },
new ColorReference() { Name="Honeydew", Argb=new Vector3 (240,255,240) },
new ColorReference() { Name="SkyBlue", Argb=new Vector3 (135,206,235) },
new ColorReference() { Name="HotPink", Argb=new Vector3 (255,105,180) },
new ColorReference() { Name="SlateBlue", Argb=new Vector3 (106,90,205) },
new ColorReference() { Name="IndianRed", Argb=new Vector3 (205,92,92) },
new ColorReference() { Name="SlateGray", Argb=new Vector3 (112,128,144) },
new ColorReference() { Name="Indigo", Argb=new Vector3 (75,0,130) },
new ColorReference() { Name="Snow", Argb=new Vector3 (255,250,250) },
new ColorReference() { Name="Ivory", Argb=new Vector3 (255,240,240) },
new ColorReference() { Name="SpringGreen", Argb=new Vector3 (0,255,127) },
new ColorReference() { Name="Khaki", Argb=new Vector3 (240,230,140) },
new ColorReference() { Name="SteelBlue", Argb=new Vector3 (70,130,180) },
new ColorReference() { Name="Lavender", Argb=new Vector3 (230,230,250) },
new ColorReference() { Name="Tan", Argb=new Vector3 (210,180,140) },
new ColorReference() { Name="LavenderBlush", Argb=new Vector3 (255,240,245) },
new ColorReference() { Name="Teal", Argb=new Vector3 (0,128,128) },
new ColorReference() { Name="LawnGreen", Argb=new Vector3 (124,252,0) },
new ColorReference() { Name="Thistle", Argb=new Vector3 (216,191,216) },
new ColorReference() { Name="LemonChiffon", Argb=new Vector3 (255,250,205) },
new ColorReference() { Name="Tomato", Argb=new Vector3 (253,99,71) },
new ColorReference() { Name="LightBlue", Argb=new Vector3 (173,216,230) },
new ColorReference() { Name="Turquoise", Argb=new Vector3 (64,224,208) },
new ColorReference() { Name="LightCoral", Argb=new Vector3 (240,128,128) },
new ColorReference() { Name="Violet", Argb=new Vector3 (238,130,238) },
new ColorReference() { Name="LightCyan", Argb=new Vector3 (224,255,255) },
new ColorReference() { Name="Wheat", Argb=new Vector3 (245,222,179) },
new ColorReference() { Name="LightGoldenrodYellow", Argb=new Vector3 (250,250,210) },
new ColorReference() { Name="White", Argb=new Vector3 (255,255,255) },
new ColorReference() { Name="LightGreen", Argb=new Vector3 (144,238,144) },
new ColorReference() { Name="WhiteSmoke", Argb=new Vector3 (245,245,245) },
new ColorReference() { Name="LightGray", Argb=new Vector3 (211,211,211) },
new ColorReference() { Name="Yellow", Argb=new Vector3 (255,255,0) },
new ColorReference() { Name="LightPink", Argb=new Vector3 (255,182,193) },
new ColorReference() { Name="YellowGreen", Argb=new Vector3 (154,205,50) },
            };
        }
    }

    public class ColorReference
    {
        public string Name { get; set; }
        public Vector3 Argb { get; set; }
    }
}
