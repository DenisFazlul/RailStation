using Station.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.Savers;
public interface ISaveFile
{
    public bool SaveToDir(Document doc, string path);
    public Document  OpenFromFile(string path);
}
