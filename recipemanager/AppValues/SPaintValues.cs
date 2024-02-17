using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipemanager
{
    internal static class SPaintValues
    {
        #region Цвета формы
        public static Color BackGroundColor { get; } = Color.FromArgb(255, 249, 249, 249);
        // public static Color FormDesignColor { get; } = Color.FromArgb(255, 8, 134, 199);
        public static Color FormDesignColor { get; } = Color.FromArgb(255, 57, 94, 162);
        #endregion
        #region цвета вкладок рецептов
        public static Color ActivePageColor { get; } = Color.FromArgb(255, 249, 249, 249);
        public static Color InActivePageColor { get; } = Color.FromArgb(255, 26, 71, 128);
        public static Color InActivePageMouseOverColor { get; } = Color.FromArgb(255, 70, 130, 180);
        #endregion


        public static Color FormHeaderColor { get; } = Color.FromArgb(255, 57, 94, 162);
        public static Color RecipesMenuBackColor { get; } = Color.FromArgb(255, 179, 216, 228);
        public static Color RecipesHeaderShadowColor { get; } = Color.FromArgb(255, 6, 97, 144);
        public static Color RecipesMenuInactiveFont { get; } = Color.FromArgb(60, Color.Black);
        public static Color RecipesMenuActiveFont { get; } = Color.FromArgb(60, Color.White);
        // Color.FromArgb(255, 78, 118, 194);

    }
}
