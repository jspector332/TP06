namespace tp06.Models;

public class codigoCesar
{
    public int corrimiento { get; set; }
    public string letra { get; set; } = "";
    public int indiceLetra { get; set; }
    public int posicionLetra { get; set; }
    public string mensaje { get; set; } = "";

    private readonly List<char> abecedario = new List<char>
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    public string codigo()
    {
        mensaje = "";
        foreach (char c in letra)
        {
            int indiceLetra = buscar(c);

            if (indiceLetra == -1)
            {
                mensaje += c;
            }
            else
            {
                int nuevaPosicion = (indiceLetra + corrimiento) % 26;
                mensaje += abecedario[nuevaPosicion];
            }
        }
        return mensaje;
    }

    public int buscar(char c)
    {
        return abecedario.IndexOf(c);
    }
}

   