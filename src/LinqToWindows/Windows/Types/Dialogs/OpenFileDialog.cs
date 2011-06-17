using System;
using System.Collections.Generic;
using System.Linq;
using Muyou.LinqToWindows.Menus;

namespace Muyou.LinqToWindows.Windows.Types.Dialogs
{
    public sealed class OpenFileDialog : Dialog
    {
        private readonly Edit _fileNameEdit;
        private readonly Button _openButton;
        private readonly Button _closeButton;

        public OpenFileDialog(IntPtr handle, string className, string text, IEnumerable<Window> childWindows, Menu menu)
            : base(handle, className, text, childWindows, menu)
        {
            _fileNameEdit = ChildWindows == null
                                ? null
                                : ChildWindows.OfType<Edit>().SingleOrDefault();
            _openButton = ChildWindows == null
                              ? null
                              : ChildWindows.OfType<Button>().Where(x => x.Text == "Open").SingleOrDefault();
            _closeButton = ChildWindows == null
                               ? null
                               : ChildWindows.OfType<Button>().Where(x => x.Text == "Cancel").SingleOrDefault();
        }

        public void SetFileName(string fileName)
        {
            _fileNameEdit.SetText(fileName);
        }

        public string GetFileName()
        {
            return _fileNameEdit.Text;
        }

        public void SelectFile(string fileName)
        {
            SetFileName(fileName);
            _openButton.Press();
        }

        public void Close()
        {
            _closeButton.Press();
        }
    }
}