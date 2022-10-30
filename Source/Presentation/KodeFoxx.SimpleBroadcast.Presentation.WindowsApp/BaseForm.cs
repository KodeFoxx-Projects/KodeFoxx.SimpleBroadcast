using KodeFoxx.SimpleBroadcast.Core.Application.Application;
using MediatR;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp
{
    public partial class BaseForm : Form
    {
        protected readonly IMediator _mediator;

        public BaseForm() { }

        public BaseForm(IMediator mediator)
        {
            InitializeComponent();
            _mediator = mediator;

            SetWindowTitle();
        }

        protected void SetWindowTitle(string? windowTitle = null)
        {
            if (String.IsNullOrWhiteSpace(windowTitle))
                SetWindowTitleBy();
            else
                SetWindowTitleBy(() => windowTitle);
        }
        private void SetWindowTitleBy(Func<string>? getWindowTitleFunc = null)
        {
            if (getWindowTitleFunc == null)
            {
                var response = _mediator.Send(new GetApplicationVersion.Request()).Result;
                Text = $"Simple Broadcast [{response.VersionString}]";
                return;
            }

            Text = "Simple Broadcast";
        }
    }
}
