namespace ProductsMvc.Helpers
{
    public static class UploadFileHelper
    {
        public async static Task<string> UploadFile(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fs = new FileStream(@$"wwwroot/{fileName}", FileMode.Create);
            await file.CopyToAsync(fs).ConfigureAwait(false);
            Console.WriteLine("copy finished");

            return fileName;
        }
    }
}
