using Artemplate.Dto;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Artemplate.Controllers
{
    [ApiController]
    [Route("api/v1/obra")]
    public class ObraController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConverter _converter;

        public ObraController(IConverter converter, IWebHostEnvironment env)
        {
            _env = env;
            _converter = converter;
        }

        [HttpGet("noite-estrelada")]
        public async Task<IActionResult> GetNoiteEstreladaHtmlAsync()
        {
            var request = new ObraRequest
            {
                Titulo = "A Noite Estrelada",
                Subtitulo = "Vincent van Gogh · 1889",
                UrlImagem = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg/330px-Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg",
                Descricao = "A Noite Estrelada, pintada por Vincent van Gogh em junho de 1889, é uma das obras mais icônicas da história da arte ocidental. Criada enquanto o artista estava internado no asilo de Saint-Paul-de-Mausole, na vila de Saint-Rémy-de-Provence, no sul da França, a obra não representa uma paisagem real observada diretamente, mas sim uma construção imaginada e simbólica. Com um céu turbulento dominado por espirais vibrantes, estrelas reluzentes e uma lua intensamente iluminada, Van Gogh traduz visualmente suas emoções e sua percepção espiritual do mundo. A vila retratada, embora inspirada em Saint-Rémy, foi modificada com elementos fictícios, como a igreja central de arquitetura nórdica, que evoca memórias de sua infância na Holanda. A pintura é frequentemente interpretada como uma expressão do conflito interno do artista, entre a serenidade da natureza e o caos da mente.",
                Biografia = "Vincent Willem van Gogh (1853–1890) foi um pintor pós-impressionista holandês cuja vida e obra exerceram uma profunda influência sobre a arte do século XX. Inicialmente, trabalhou como pastor e missionário antes de se dedicar à pintura aos 27 anos. Embora tenha produzido mais de 2.000 obras em pouco mais de uma década — incluindo cerca de 860 pinturas a óleo — Van Gogh vendeu apenas uma pintura em vida. Suas obras são marcadas pelo uso expressivo da cor, pinceladas intensas e composições emotivas que romperam com o naturalismo tradicional. Durante sua vida, enfrentou severas crises de saúde mental, incluindo episódios psicóticos e depressão profunda, o que o levou a períodos de internação. Em 1890, morreu aos 37 anos em Auvers-sur-Oise, França, devido a um ferimento por arma de fogo, possivelmente autoinfligido. Após sua morte, Van Gogh foi amplamente reconhecido como um dos maiores gênios artísticos da história moderna, sendo suas obras hoje exibidas nas mais prestigiadas coleções de arte do mundo.",
                NomeArtista = "Vincent van Gogh",
                Ano = "1889",
                Tecnica = "Óleo sobre tela",
                Dimensoes = "73.7 cm x 92.1 cm",
                Localizacao = "MoMA, Nova York",
                Categorias = "Pós-impressionismo, Paisagem, Céu noturno"
            };

            return await GerarPdfObraAsync(request);
        }

        [HttpPost("gerar-pdf")]
        public async Task<IActionResult> GerarPdfObraAsync([FromBody] ObraRequest request)
        {
            var templatePath = Path.Combine(_env.ContentRootPath, "Assets", "Templates", "quadro_template.html");
            var htmlContent = System.IO.File.ReadAllText(templatePath);

            using var httpClient = new HttpClient();
            var imageBytes = await httpClient.GetByteArrayAsync(new Uri(request.UrlImagem));
            var base64 = Convert.ToBase64String(imageBytes);
            var dataUri = $"data:image/jpeg;base64,{base64}";

            htmlContent = htmlContent
                .Replace("{{titulo}}", request.Titulo ?? "")
                .Replace("{{subtitulo}}", request.Subtitulo ?? "")
                .Replace("{{url_imagem}}", dataUri)
                .Replace("{{descricao}}", request.Descricao ?? "")
                .Replace("{{biografia}}", request.Biografia ?? "")
                .Replace("{{nome_artista}}", request.NomeArtista ?? "")
                .Replace("{{ano}}", request.Ano ?? "")
                .Replace("{{tecnica}}", request.Tecnica ?? "")
                .Replace("{{dimensoes}}", request.Dimensoes ?? "")
                .Replace("{{localizacao}}", request.Localizacao ?? "")
                .Replace("{{categorias}}", request.Categorias ?? "");

            var doc = new HtmlToPdfDocument
            {
                GlobalSettings = new GlobalSettings
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Landscape,
                },
                Objects = {
                    new ObjectSettings
                    {
                        HtmlContent = htmlContent,
                        WebSettings = new WebSettings
                        {
                            DefaultEncoding = "utf-8",
                            LoadImages = true
                        }
                    }
                }
            };

            var pdf = _converter.Convert(doc);
            return File(pdf, "application/pdf", "obra.pdf");
        }
    }
}
