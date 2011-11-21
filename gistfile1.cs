
using System;
using System.Web;
using System.Web.UI;
using System.IO;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string root_path = Server.MapPath("~/");
        string FILENAME = root_path + "test.jpg";
        if( File.Exists( FILENAME ) )
        {
            File.Delete( FILENAME );
        }
        
        HttpPostedFile pf = Request.Files[0];
        
        using( FileStream fs = File.Create( FILENAME ) )
        using( BinaryReader br = new BinaryReader( pf.InputStream ) )
        using( BinaryWriter bw = new BinaryWriter( fs ) )
        {
            int BUFFER_SIZE = 4000;
            int position = 0;
            int size_read = -1;
            byte[] buffer = new byte[BUFFER_SIZE];
            // Read all
            while( position <= pf.InputStream.Length && size_read != 0 )
            {
                size_read = br.Read( buffer, 0, BUFFER_SIZE );
                bw.Write( buffer, 0, size_read );
                position += size_read;
            }
        }

    }
}
