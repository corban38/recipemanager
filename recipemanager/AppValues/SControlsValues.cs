using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipemanager
{
    internal static class SControlsValues
    {
        public enum ButtonsAction
        {
            Close,
            Minimize,
            Move,
            Default
        }
        public enum ButtonsType
        {
            New,
            Edit,
            Delete,
            Save,
            Cancel            
        }
        public enum RecipeMode
        {
            Append,
            Edit,
            Read
        }
        public static string EditIcon { get; } = "\ue70f";
        public static string AddIcon { get; } = "\ue710";
        public static string DeleteIcon { get; } = "\ue738";
        public static string CheckMarkIcon { get; } = "\ue73e";
        public static string SaveIcon { get; } = "\ue8fb";
        public static string CancelIcon { get; } = "\ue711";
        public static string ExploreContent { get; } = "\uf164"; //eccd
        public static string CollapseContent { get; } = "\uf166"; //f165
        public static string AddNewRecipe { get; } = "\ued0e"; //e82e f000
        public static string CloseBtnIcon { get; } = "\uE8BB";
        public static string MinimizeBtnIcon { get; } = "\uE921";

        public static Control? FindParent(Control theControl, Type _find_type)
        {
            Control? rControl = theControl.Parent;
            if (rControl != null)
            {
                if (rControl.GetType() != _find_type)
                {
                    rControl = FindParent(rControl, _find_type);
                }
            }
            return rControl;
        }
        public static Control? FindChild(Control theControl, Type _find_type)
        {
            Control? _child = null;

            bool _find = theControl.GetType() == _find_type;
            if (_find) { _child = theControl; }
            else
            {
                foreach (Control _c in theControl.Controls)
                {
                    _child = FindChild(_c, _find_type);
                    if (_child != null && _child.GetType() == _find_type)
                    {
                        break;
                    }
                }
            }
            return _child;
        }
    }
}
