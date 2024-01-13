using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models;

namespace MovieMVC.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> movies;
        Random rand = new Random();
        void CargaInicial()
        {
            movies.Add(new Movie(rand.Next(), "Gente grande", "Comédia", "Dennis Dugan", "A morte do treinador de basquete de infância de velhos amigos reúne a turma no mesmo lugar que celebraram um campeonato anos atrás. Os amigos, acompanhados de suas esposas e filhos, descobrem que idade não significa o mesmo que maturidade."));
            movies.Add(new Movie(rand.Next(), "Click", "Comédia", "Frank Coraci", "Um arquiteto casado e com filhos está cada vez mais frustrado por passar a maior parte de seu tempo trabalhando. Um dia, ele encontra um inventor excêntrico que lhe dá um controle remoto universal, com capacidade de acelerar o tempo. No início, ele usa o aparelho para acelerar qualquer momento tedioso, mas se dá conta de que está acelerando o tempo demais e deixando de viver preciosos momentos em família. Desesperado, ele procura o inventor para ajudá-lo a reverter o que fez."));
            movies.Add(new Movie(rand.Next(), "Gente grande 2", "Comédia", "Dennis Dugan", "Lenny Feder e a família se mudam para a própria cidade natal com o objetivo ficarem perto dos amigos, mas acabam tendo que enfrentar alguns fantasmas do passado, como a covardia diante de valentões e o famigerado bullying na escola."));
        } 

        public MovieController()
        {
            if (movies == null)
            {
                movies = new List<Movie>();
                CargaInicial();
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
        
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    return View(m);
                }
            }
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    return View(m);
                }
            }
            return RedirectToAction("Index");

        }

        public IActionResult Register()
        {
            return View();
        }

        public bool RemoverFilme(int id)
        {
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    movies.Remove(m);
                    return true;
                }
            }
            return false;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool removido = RemoverFilme(id);

            if (removido)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string title, string genre, string diretor, string description)
        {
            Movie movie = new Movie(rand.Next(), title, genre, diretor, description);

            movies.Add(movie);
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(int id, string title, string genre, string diretor, string description)
        {
            Movie m = null;
            foreach(Movie movie in movies)
            {
                if (movie.Id == id)
                {
                    m = movie;
                }
            }

            if (m == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                m.Title = title;
                m.Genre = genre;
                m.Diretor = diretor;
                m.Description = description;
                return RedirectToAction("Index");
            }
        }

        public IActionResult ConfirmDelete(int id)
        {
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    return View(m);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
