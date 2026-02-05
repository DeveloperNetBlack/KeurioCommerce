using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.ApplicationService.Commons.Dtos
{
    public class DownloadFileDto<TData>
    {
        public TData FileContents { get; set; }
        public string ContentType { get; set; } = null!;
        public string FileName { get; set; } = null!;
    }
}
