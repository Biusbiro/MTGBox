using MTGBox.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.DAO
{
    class ImageUrisDAO
    {
        public void Insert(ImageUris imageUris)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into image_uris (small, normal, large, png, art_crop, border_crop) values (@small, @normal, @large, @png, @art_crop, @border_crop)";

            sqlCommand.Parameters.AddWithValue("@small", imageUris.Small);
            sqlCommand.Parameters.AddWithValue("@normal", imageUris.Normal);
            sqlCommand.Parameters.AddWithValue("@large", imageUris.Large);
            sqlCommand.Parameters.AddWithValue("@png", imageUris.Png);
            sqlCommand.Parameters.AddWithValue("@art_crop", imageUris.ArtCrop);
            sqlCommand.Parameters.AddWithValue("@border_crop", imageUris.BorderCrop);

            Db.Execute(sqlCommand);
        }

        public void Update(ImageUris imageUris)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update image_uris set small = @small, normal = @normal, large = @large, png = @png, art_crop = @art_crop, border_crop = @border_crop where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", imageUris.Id);
            sqlCommand.Parameters.AddWithValue("@small", imageUris.Small);
            sqlCommand.Parameters.AddWithValue("@normal", imageUris.Normal);
            sqlCommand.Parameters.AddWithValue("@large", imageUris.Large);
            sqlCommand.Parameters.AddWithValue("@png", imageUris.Png);
            sqlCommand.Parameters.AddWithValue("@art_crop", imageUris.ArtCrop);
            sqlCommand.Parameters.AddWithValue("@border_crop", imageUris.BorderCrop);

            Db.Execute(sqlCommand);
        }

        public void Delete(ImageUris imageUris)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from image_uris where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", imageUris.Id);

            Db.Execute(sqlCommand);
        }

        public ImageUris SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from image_uris where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            ImageUris imageUris = new ImageUris();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                imageUris.Id = (Int32)sqlDataReader["id"];
                imageUris.Small = (String)sqlDataReader["small"];
                imageUris.Normal = (String)sqlDataReader["normal"];
                imageUris.Large = (String)sqlDataReader["large"];
                imageUris.Png = (String)sqlDataReader["png"];
                imageUris.ArtCrop = (String)sqlDataReader["art_crop"];
                imageUris.BorderCrop = (String)sqlDataReader["border_crop"];

                return imageUris;
            }
            else
            {
                return null;
            }
        }

        public List<ImageUris> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from image_uris";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<ImageUris> listImageUris = new List<ImageUris>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    ImageUris imageUris = new ImageUris();
                    imageUris.Id = (Int32)sqlDataReader["id"];
                    imageUris.Small = (String)sqlDataReader["small"];
                    imageUris.Normal = (String)sqlDataReader["normal"];
                    imageUris.Large = (String)sqlDataReader["large"];
                    imageUris.Png = (String)sqlDataReader["png"];
                    imageUris.ArtCrop = (String)sqlDataReader["art_crop"];
                    imageUris.BorderCrop = (String)sqlDataReader["border_crop"];
                    listImageUris.Add(imageUris);
                }
                sqlDataReader.Read();

                return listImageUris;
            }
            else
            {
                return null;
            }
        }
    }
}
