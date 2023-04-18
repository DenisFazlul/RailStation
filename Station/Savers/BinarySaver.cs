using Station.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Station.Savers;
public class BinarySaver : ISaveFile
{
    public Document OpenFromFile(string path) {
        Document document = new Document();
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(path, FileMode.Open)) {
            document = (Document) formatter.Deserialize(fs);

            
        }
        return document;
    }
    public bool SaveToDir(Document doc, string path) {

        bool Sucsees = false;
        BinaryFormatter formatter = new BinaryFormatter();
        // получаем поток, куда будем записывать сериализованный объект
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate)) {
            formatter.Serialize(fs, doc);
            Sucsees = true;
            
        }
        return Sucsees;



    }
}
