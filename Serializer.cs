using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MinTetris
{
    public class Serializer
    {
        //Save to file
        //Збереження у файл
        public void Serialize(string path, Object obj)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, obj);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Cannot save " + path + ". Reason: \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        //Load from file
        //завантаження з файлу
        public object Deserialize(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Object obj;
            try
            {
                obj = formatter.Deserialize(fs);
                return obj;
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Cannot save " + path + ". Reason: \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
