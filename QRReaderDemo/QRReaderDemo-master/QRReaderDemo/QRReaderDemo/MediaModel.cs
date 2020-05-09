using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QRReaderDemo
{
    class MediaModel
    {
        public Guid MediaID { get; set; }
        public string Path { get; set; }
        public DateTime LocalDateTime { get; set; }
        private FileImageSource source = null;
        public FileImageSource Source => source ?? (source = new FileImageSource() { File = Path });
    }
}
