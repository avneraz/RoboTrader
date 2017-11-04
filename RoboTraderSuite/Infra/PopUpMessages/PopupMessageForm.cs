using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infra.Extensions.ArrayExtensions;
using Infra.Properties;

namespace Infra.PopUpMessages
{
    public partial class PopupMessageForm : Form
    {
        public PopupMessageForm()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private Form HostForm { get; set; }
        private readonly CancellationTokenSource _cancellationTokenSource;
        public static void ShowMessage(string msg, Color backGroundColor, Form hostForm, int popupTimeSec = 5, bool withSiren = false)
        {
            var pmForm = new PopupMessageForm();
            pmForm.SetPopupParameters(msg,backGroundColor);
            if (hostForm != null)
                pmForm.HostForm = hostForm;
                
            pmForm.Show();
            if (withSiren)
                pmForm.PlaySiren();
            //GeneralTimer.GeneralTimerInstance.AddTask()
            if(popupTimeSec > 0)
                pmForm.ClosePopupMessageInSec(popupTimeSec);
           
        }
        
        internal async void ClosePopupMessageInSec(int popupTimeSec)
        {
            Action action = () =>
            {
                Close();
                StopPlayer();
                Application.DoEvents();
            };
            try
            {
                await Task.Delay(popupTimeSec * 1000, _cancellationTokenSource.Token);
                Invoke(action);
            }
            catch (OperationCanceledException)
            {
                Invoke(action);
            }
        }

      

        internal virtual void SetPopupParameters(string msg, Color backGroundColor)
        {
            lblMessage.BackColor = backGroundColor;
            lblClosePopupMessage.BackColor = backGroundColor;

            lblMessage.Image = backGroundColor == Color.Red ? Resources.Exclamation : Resources.Thumbs_up;

            lblMessage.Text = msg;
        }
        private void lblMessage_DoubleClick(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
            StopPlayer();
        }

        private void lblClosePopupMessage_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            StopPlayer();
            Close();

        }

        protected int _initializedTop;
        private void PopupMessageForm_Load(object sender, EventArgs e)
        {
            _initializedTop = this.Top;
            if(HostForm != null)
                this.SetFormOnSameScreen(HostForm);
        }
        private System.Media.SoundPlayer _soundPlayer;
        public SoundPlayer SoundPlayer
        {
            get { return _soundPlayer ?? (_soundPlayer = new SoundPlayer()); }
        }
        //GlassPingSound

        internal void PlayGlassPingSound()
        {
            Stream stream = Resources.GlassPingSound;

            SoundPlayer.Stream = stream;
            SoundPlayer.Play();

        }
        internal void PlaySiren()
        {
            Stream stream = Resources.SIREN_247265934;

            SoundPlayer.Stream = stream;
            SoundPlayer.Play();
        }

        private void StopPlayer()
        {
            if (SoundPlayer != null)
            {
                SoundPlayer.Stop();
            }
        }
    }
}
