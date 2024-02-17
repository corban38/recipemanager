using System.Security.Principal;

namespace recipemanager
{
    public partial class FMainForm : Form
    {
        Point _mouseStart;
        bool _mouseMove = false;
        public FMainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SFontValues.FontsInitialize();

            AddContriolsOnForm();
            
            BackColor = SPaintValues.FormDesignColor;
            panel1.BackColor = SPaintValues.BackGroundColor;
        }

        private void FormMoving() 
        {   
            StartMoveForm();
            {
                Point _mousePointer = PointToClient(MousePosition);
                // получаем новую точку положения формы
                int _deltaX = _mousePointer.X - _mouseStart.X;
                int _deltaY = _mousePointer.Y - _mouseStart.Y ;               
                // устанавливаем положение формы
                this.Location = new Point(this.Location.X + _deltaX,
                  this.Location.Y + _deltaY);
            }
        }

        private void AddContriolsOnForm()
        {

            /*FormHeader _formHeaderControlsPanel = new FormHeaderControlsPanel();
            Controls.Add(_formHeaderControlsPanel);*/
            FormHeader _header = new FormHeader();
            _header.HeaderBtnsNotify += HeaderBtnsAction;   // Добавляем обработчик для событий ForHeader
                                                            
         
            Controls.Add(_header);
/*
            FormFooter _footer = new FormFooter();
            Controls.Add(_footer);
            FormDataArea _formArea = new FormDataArea();
            Controls.Add(_formArea);
            Controls.SetChildIndex(_header, 0);
            Controls.SetChildIndex(_formHeaderControlsPanel, 0);
            Controls.SetChildIndex(_footer, 0);
            Controls.SetChildIndex(_formArea, 0);
            _formArea.Initialize();
            _formHeaderControlsPanel.Initialize();
*/
        }

        private void StartMoveForm()
        {
            if (!_mouseMove)
            {   
                _mouseMove = true;
                // получаем стартовую точку положения мыши
                _mouseStart = PointToClient(MousePosition);
            }
            
            
        }
        private void HeaderBtnsAction(SControlsValues.ButtonsAction _btnsAction)
        {
           switch (_btnsAction)
            {
                case SControlsValues.ButtonsAction.Close:
                    Close();
                    break;
                case SControlsValues.ButtonsAction.Minimize:
                    WindowState = FormWindowState.Minimized; 
                    break;
                case SControlsValues.ButtonsAction.Move:
                    
                    FormMoving();
                    break;
                default : _mouseMove = false;
                    break;
            }
            
            
        }
    }
}
