using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipemanager
{
    internal class FormHeader:Control
    {
        #region нажатие кнопок в заголовке
        public delegate void HeaderBtnsHandler(SControlsValues.ButtonsAction _btnsAction);
        public event HeaderBtnsHandler? HeaderBtnsNotify;              // Определение события
        #endregion
        bool _mouse_over_close_btn = false;
        bool _mouse_over_minimize_btn = false;
        Rectangle _close_btn_rect = new Rectangle(0, 0, 24, 24);
        Rectangle _form_minimize_box = new Rectangle(0, 0, 24, 24);
        
        bool isDrag;
        public string Caption { get; set; } = "Менеджер рецептов";
        public bool MinimizeBtnVisible { get; set; } = true;

        public FormHeader()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.ResizeRedraw |
               ControlStyles.Selectable |
               ControlStyles.SupportsTransparentBackColor |
               ControlStyles.UserPaint,
               true);
            DoubleBuffered = true;
            BackColor = SPaintValues.FormHeaderColor;
            Height = 25;

            Width = 100;
            Dock = DockStyle.Top;
        }



        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point p = e.Location;

            if (_form_minimize_box.Contains(p))
            {
                _mouse_over_minimize_btn = true;
            }
            else
            {
                _mouse_over_minimize_btn = false;
            }

            if (_close_btn_rect.Contains(p))
            {
                _mouse_over_close_btn = true;
            }
            else
            {
                _mouse_over_close_btn = false;
            }
            // если нажата левая кнопка мыши
            if ((e.Button is MouseButtons.Left) & isDrag)
            { 
                HeaderBtnsNotify?.Invoke(SControlsValues.ButtonsAction.Move);
            }
            else
            {
                HeaderBtnsNotify?.Invoke(SControlsValues.ButtonsAction.Default);
            }
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouse_over_close_btn = false;
            _mouse_over_minimize_btn = false;
            Invalidate();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Point p = e.Location;

            if (_form_minimize_box.Contains(p))
            {
                HeaderBtnsNotify?.Invoke(SControlsValues.ButtonsAction.Minimize);
            }
            else
            if (_close_btn_rect.Contains(p))
            {
                HeaderBtnsNotify?.Invoke(SControlsValues.ButtonsAction.Close);   // 2.Вызов события 
                
            }
            else
            {
                HeaderBtnsNotify?.Invoke(SControlsValues.ButtonsAction.Default);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Font _font_ = SFontValues.FontFormHeader();
            Brush _brush = new SolidBrush(SPaintValues.BackGroundColor);
            StringFormat _sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center
            };
            Graphics _graf = e.Graphics;
            Size _caption_size = _graf.MeasureString(Caption, _font_).ToSize();
            _caption_size.Width += 1;
            _caption_size.Height = Height;
            Rectangle _caption_rect = this.ClientRectangle;
            _caption_rect.Offset(2, 0);
            _caption_rect.Size = _caption_size;
            _graf.DrawString(Caption, _font_, _brush, _caption_rect, _sf);

            _sf.Alignment = StringAlignment.Center;
            if (_mouse_over_close_btn)
            {
                _graf.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.White)), _close_btn_rect);
            }

            _graf.DrawString(SControlsValues.CloseBtnIcon,
                SFontValues.FontIconsFormHeader,//  FormActionBtnsFont,
                new SolidBrush(Color.White),
                _close_btn_rect,
                _sf);
            if (MinimizeBtnVisible)
            {
                if (_mouse_over_minimize_btn)
                {
                    _graf.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.White)), _form_minimize_box);
                }
                _graf.DrawString(SControlsValues.MinimizeBtnIcon,//Minimize,
                    SFontValues.FontIconsFormHeader, //FormActionBtnsFont,
                    new SolidBrush(Color.White),
                    _form_minimize_box,
                    _sf);
            }

        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetBtnsRectangle();

        }
        private void SetBtnsRectangle()
        {
            int btn_offset_x = this.Width - this.Height + 1;
            _close_btn_rect.X = 0;
            _close_btn_rect.Y = 0;
            _form_minimize_box.X = 0;
            _form_minimize_box.Y = 0;
            _close_btn_rect.Width = this.Height - 1;
            _close_btn_rect.Height = this.Height - 1;
            _close_btn_rect.Offset(btn_offset_x, 0);
            btn_offset_x -= _close_btn_rect.Width;
            _form_minimize_box.Width = this.Height - 1;
            _form_minimize_box.Height = this.Height - 1;
            _form_minimize_box.Offset(btn_offset_x, 0);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            // если нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
                if (!_form_minimize_box.Contains(e.Location) && !_close_btn_rect.Contains(e.Location))
                {
                    isDrag = true;
                }
                else
                {
                    isDrag = false;
                }

            }

        }
    }
}
