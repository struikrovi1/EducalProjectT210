namespace EducalProjectT210.Helpers
{
    public static class PictureHelper
    {

        public static string UploadPicture(IFormFile PhotoUrl, IWebHostEnvironment envor)
        {
            string PhotoName = Guid.NewGuid().ToString() + PhotoUrl.FileName;//ctobi dva fayla imeli raznie nazvaniya
            //string rootName = _enviro.WebRootPath; ctobi nayti wwwroot
            string rootName = Path.Combine(envor.WebRootPath, "uploads"); //wwwroot+uploads
            string rootPhoto = Path.Combine(rootName, PhotoName); ///wwwroot+uploads+photo

            using FileStream myStrem = new FileStream(rootPhoto, FileMode.Create); // eto process sozdaniya kartinki na komputere
            PhotoUrl.CopyTo(myStrem); //copy to wwwroot


            return "/uploads/" + PhotoName;
        }
    }
}
