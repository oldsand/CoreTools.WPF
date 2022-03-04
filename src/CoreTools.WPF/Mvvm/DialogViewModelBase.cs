using System;
using CoreTools.WPF.Prism;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
// ReSharper disable MemberCanBeProtected.Global These need to be public for binding purposes.

namespace CoreTools.WPF.Mvvm
{
    public class DialogViewModelBase : ViewModelBase, IDialogAware, IRegionManagerAware
    {
        public DialogViewModelBase()
        {
            ApplyCommand = new DelegateCommand(ExecuteApplyCommand, ExecuteCanApplyCommand);
            SaveCommand = new DelegateCommand(ExecuteSaveCommand, ExecuteCanSaveCommand);
            OkCommand = new DelegateCommand(ExecuteOkCommand);
            CancelCommand = new DelegateCommand(ExecuteCancelCommand);
            YesCommand = new DelegateCommand(ExecuteYesCommand);
            NoCommand = new DelegateCommand(ExecuteNoCommand);
            RetryCommand = new DelegateCommand(ExecuteRetryCommand);
            AbortCommand = new DelegateCommand(ExecuteAbortCommand);
        }

        public virtual DelegateCommand ApplyCommand { get; }

        public virtual DelegateCommand SaveCommand { get; }

        public virtual DelegateCommand OkCommand { get; }

        public virtual DelegateCommand CancelCommand { get; }

        public virtual DelegateCommand YesCommand { get; }

        public virtual DelegateCommand NoCommand { get; }

        public virtual DelegateCommand RetryCommand { get; }

        public DelegateCommand AbortCommand { get; }

        public IRegionManager? RegionManager { get; set; }

        public event Action<IDialogResult>? RequestClose;

        protected virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }

        protected virtual void ExecuteApplyCommand()
        {
        }

        protected virtual bool ExecuteCanApplyCommand()
        {
            return false;
        }

        protected virtual void ExecuteSaveCommand()
        {
        }

        protected virtual bool ExecuteCanSaveCommand()
        {
            return false;
        }

        protected virtual void ExecuteOkCommand()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        protected virtual void ExecuteCancelCommand()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.Cancel));
        }

        protected virtual void ExecuteYesCommand()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.Yes));
        }

        protected virtual void ExecuteNoCommand()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.No));
        }

        protected virtual void ExecuteRetryCommand()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.Retry));
        }

        protected virtual void ExecuteAbortCommand()
        {
            RaiseRequestClose(new DialogResult(ButtonResult.Abort));
        }
    }
}