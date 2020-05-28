using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Core.Model
{
    public class Attachment
    {
        public DateTimeOffset CreatedAt
        {
            get;
            set;
        }

        [Required]
        public byte[] Data
        {
            get;
            set;
        }

        [Required]
        public string Extension
        {
            get;
            set;
        }

        [Required]
        public string FileName
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }

        public string MimeType
        {
            get;
            set;
        }

        public DateTimeOffset ModifiedAt
        {
            get;
            set;
        }

        public Attachment()
        {
        }
    }
}
