using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipemanager
{
    internal static class SFontValues
    {
        static PrivateFontCollection _f_collect = new PrivateFontCollection();
        // E8BB ChromeClose, E921 Minimize, E922 Maximize, E923 Restore, e82e AddDictionary
        public static Font? FontIconCloseBtnPage { get; private set; }
        public static Font? FontCategoryItem { get; private set; }
        public static Font? FontCategorySubItem { get; private set; }
        public static Font FontIconsFormHeader { get; private set; } = new Font("Segoe Fluent Icons", 10f, GraphicsUnit.Pixel);

        public static void FontsInitialize()
        {
            _f_collect.AddFontFile(@"Fonts\Segoe-Fluent-Icons\Segoe Fluent Icons.ttf");//0
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\SegoeUI-VF.ttf");//1
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Text-Semilight.ttf");//2
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Text-Semibold.ttf");//3
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Text-Light.ttf");//4
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Text-Bold.ttf");//5
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Text.ttf");//6
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Small-Semilight.ttf");//7
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Small-Semibold.ttf");//8
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Small-Light.ttf");//9
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Small-Bold.ttf");//10
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Small.ttf");//11
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Display-Semilight.ttf");//12
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Display-Semibold.ttf");//13
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Display-Light.ttf");//14
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Display-Bold.ttf");//15
            _f_collect.AddFontFile(@"Fonts\SegoeUI-VF\Segoe-UI-Variable-Static-Display.ttf");//16

            FontIconCloseBtnPage = new Font(_f_collect.Families[0], 8);
            FontIconsFormHeader = new Font(_f_collect.Families[0], 10, GraphicsUnit.Pixel);
            FontCategoryItem = new Font(_f_collect.Families[3], 10);
            FontCategorySubItem = new Font(_f_collect.Families[8], 10);
        /*    FontHeaderBtn = new Font(_f_collect.Families[3], 10);
            FontRecipeDataHeader = new Font(_f_collect.Families[15], 16);
            FontRecipeDataIngredientItem = new Font(_f_collect.Families[3], 10);
            FontRecipeCookingMethod = new Font(_f_collect.Families[11], 12);*/
        }
        public static Font FontFormHeader()
        {
            return new Font(_f_collect.Families[13], 16, FontStyle.Regular, GraphicsUnit.Pixel);
        }

    }
}
