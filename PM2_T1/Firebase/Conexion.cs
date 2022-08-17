using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2_T1P3.Firebase
{
    public class Conexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://pm2t1p3-b4f0a-default-rtdb.firebaseio.com/");
    }
}
