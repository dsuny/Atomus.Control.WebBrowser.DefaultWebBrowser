using System;
using System.Windows.Forms;

namespace Atomus.Control.WebBrowser
{
    public partial class DefaultWebBrowser : UserControl, IAction
    {
        private AtomusControlEventHandler beforeActionEventHandler;
        private AtomusControlEventHandler afterActionEventHandler;
        
        #region Init
        public DefaultWebBrowser()
        {
            InitializeComponent();
        }
        #endregion

        #region Dictionary
        #endregion

        #region Spread
        #endregion

        #region IO
        object IAction.ControlAction(ICore sender, AtomusControlArgs e)
        {
            try
            {
                this.beforeActionEventHandler?.Invoke(this, e);

                switch (e.Action)
                {
                    case "Url":
                        this.webBrowser1.Navigate((string)e.Value);
                        return true;

                    default:
                        return false;
                }
            }
            finally
            {
                this.afterActionEventHandler?.Invoke(this, e);
            }
        }
        #endregion

        #region Event
        event AtomusControlEventHandler IAction.BeforeActionEventHandler
        {
            add
            {
                this.beforeActionEventHandler += value;
            }
            remove
            {
                this.beforeActionEventHandler -= value;
            }
        }
        event AtomusControlEventHandler IAction.AfterActionEventHandler
        {
            add
            {
                this.afterActionEventHandler += value;
            }
            remove
            {
                this.afterActionEventHandler -= value;
            }
        }

        private void DefaultWebBrowser_Load(object sender, EventArgs e)
        {
            string defaultUri;

            try
            {
                defaultUri = this.GetAttribute("DefaultUri");
                this.webBrowser1.Navigate(defaultUri);
            }
            catch (Exception exception)
            {
                this.MessageBoxShow(this, exception);
            }
        }
        #endregion

        #region "ETC"
        #endregion
    }
}
