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

        [HttpGet("nascimento-de-venus")]
        public async Task<IActionResult> GetNascimentoDeVenusHtmlAsync()
        {
            var request = new ObraRequest
            {
                Titulo = "O Nascimento de Vênus",
                Subtitulo = "Sandro Botticelli · c. 1485",
                UrlImagem = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg/1920px-Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg",
                Descricao = "O Nascimento de Vênus é uma das obras mais emblemáticas do Renascimento italiano. Pintada por Sandro Botticelli por volta de 1485, retrata a deusa romana emergindo do mar sobre uma concha, sendo recebida por uma das Horas, deidades que representam as estações. A pintura é celebrada pela elegância linear e pela idealização da forma humana, representando a beleza divina e a mitologia clássica. Vênus, com sua expressão serena e corpo gracioso, simboliza tanto o amor espiritual quanto o físico.",
                Biografia = "Sandro Botticelli (c. 1445–1510) foi um dos principais pintores do Renascimento italiano. Ativo em Florença, Botticelli era conhecido por suas obras que combinavam elegância formal com narrativas mitológicas e religiosas. Trabalhou sob o patrocínio da poderosa família Médici e deixou um legado artístico que influenciou gerações futuras. Seu estilo refinado e poético é reconhecido por sua delicadeza e riqueza simbólica.",
                NomeArtista = "Sandro Botticelli",
                Ano = "c. 1485",
                Tecnica = "Têmpera sobre tela",
                Dimensoes = "172.5 cm × 278.9 cm",
                Localizacao = "Galeria Uffizi, Florença",
                Categorias = "Renascimento, Mitologia, Arte clássica"
            };

            return await GerarPdfObraAsync(request);
        }

        [HttpGet("mona-lisa")]
        public async Task<IActionResult> GetMonaLisaHtmlAsync()
        {
            var request = new ObraRequest
            {
                Titulo = "Mona Lisa",
                Subtitulo = "Leonardo da Vinci · c. 1503–1506",
                UrlImagem = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg/330px-Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg",
                Descricao = "A Mona Lisa, pintada por Leonardo da Vinci entre 1503 e 1506, é considerada a pintura mais famosa do mundo. A obra retrata uma mulher com um sorriso enigmático, vestida de forma modesta e posicionada diante de uma paisagem idealizada. O uso do sfumato — técnica que suaviza as transições de cor e luz — confere à figura uma aura etérea e misteriosa. A identidade da modelo é amplamente aceita como sendo Lisa Gherardini, esposa de um comerciante florentino. Sua expressão ambígua, combinada com a habilidade técnica de Da Vinci, transformou a obra em um símbolo de perfeição artística e um enigma que fascina estudiosos até hoje.",
                Biografia = "Leonardo da Vinci (1452–1519) foi um dos maiores gênios do Renascimento, atuando como pintor, engenheiro, cientista, inventor e anatomista. Conhecido por sua incansável curiosidade e espírito visionário, deixou um legado que vai muito além da arte. Suas contribuições à ciência, engenharia e medicina foram documentadas em milhares de páginas de cadernos. Como pintor, é reconhecido por obras como A Última Ceia e a própria Mona Lisa, nas quais combinou observação aguda com inovação técnica.",
                NomeArtista = "Leonardo da Vinci",
                Ano = "c. 1503–1506",
                Tecnica = "Óleo sobre madeira",
                Dimensoes = "77 cm x 53 cm",
                Localizacao = "Museu do Louvre, Paris",
                Categorias = "Renascimento, Retrato"
            };

            return await GerarPdfObraAsync(request);
        }

        [HttpGet("guernica")]
        public async Task<IActionResult> GetGuernicaHtmlAsync()
        {
            var request = new ObraRequest
            {
                Titulo = "Guernica",
                Subtitulo = "Pablo Picasso · 1937",
                UrlImagem = "https://upload.wikimedia.org/wikipedia/en/7/74/PicassoGuernica.jpg",
                Descricao = "Guernica é uma das mais poderosas obras de protesto contra a guerra já criadas. Pintada por Pablo Picasso em resposta ao bombardeio da cidade de Guernica, no País Basco, durante a Guerra Civil Espanhola, a obra utiliza uma paleta monocromática em preto, branco e cinza para retratar o sofrimento humano e animal causado pelo conflito. Com figuras distorcidas e símbolos como o touro, o cavalo ferido e a mulher com uma lâmpada, Picasso construiu uma alegoria visual angustiante da violência, da dor e da desesperança provocadas pela guerra moderna.",
                Biografia = "Pablo Picasso (1881–1973) foi um pintor e escultor espanhol, cofundador do movimento cubista e um dos artistas mais influentes do século XX. Inovador incansável, Picasso explorou diversos estilos ao longo de sua carreira, como o período azul, rosa, cubismo e surrealismo. Produziu mais de 20.000 obras, incluindo pinturas, esculturas, cerâmicas e gravuras. 'Guernica' é uma de suas obras mais politicamente engajadas, tendo se tornado um símbolo universal da paz.",
                NomeArtista = "Pablo Picasso",
                Ano = "1937",
                Tecnica = "Óleo sobre tela",
                Dimensoes = "349 cm × 776 cm",
                Localizacao = "Museu Reina Sofía, Madri",
                Categorias = "Cubismo, Arte política, Antiguerra"
            };

            return await GerarPdfObraAsync(request);
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
            return File(pdf, "application/pdf", $"{request.Titulo}.pdf");
        }
    }
}
