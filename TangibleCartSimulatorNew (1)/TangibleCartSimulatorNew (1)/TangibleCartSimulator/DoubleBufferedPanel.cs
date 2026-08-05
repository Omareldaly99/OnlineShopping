using System.Windows.Forms;

namespace TangibleCartSimulator
{
    
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            
            this.DoubleBuffered = true;
        }
    }
}