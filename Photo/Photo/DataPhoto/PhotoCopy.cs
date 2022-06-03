using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Photo.DataPhoto
{
    [Table("Photo")]
    public class PhotoCopy
    {
        public PhotoCopy()
        {
        }

        public PhotoCopy(string name, string image)
        {
            Name = name;
            Imagepath = image;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public string Imagepath { get; set; }
    }


}
