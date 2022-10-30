using MediatR;

namespace KodeFoxx.SimpleBroadcast.Presentation.WindowsApp;

public partial class Main : BaseForm
{
    public Main(IMediator mediator) : base(mediator)
    {
        InitializeComponent();        
        SetWindowTitle();
        SetHeader();
    }

    private void SetHeader()
    {
        headerPanel.BackgroundImageLayout = ImageLayout.Stretch;
        headerPanel.BackgroundImage = Image.FromFile(
            Path.Combine("Resources", "Images", "Header.png")
        );        
    }
}
