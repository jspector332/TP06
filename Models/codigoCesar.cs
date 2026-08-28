namespace tp06.Models;
publlic class codigoCesar
{
   public  int corrimiento {get;set;}
    public string letra {get;set;}
    public int indiceLetra {get;set;}
    public int posicionLetra {get;set;}
    public string mensaje {get;set;} = "";
    list <char> abecedario = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' } = new list <char>;
    
    private string codigo(){
        
        foreach (char c in letra)
        {
        indiceLetra = buscar(c, corrimiento, abecedario);
        posicionLetra = (indiceLetra + corrimiento ) %26;
       
        
        if (indiceLetra == -1){
            mensaje += c;
        }
            
        else{
             mensaje += abecedario[posicionLetra];
        }
           
        }
         return(mensaje);
    }
    

    
}

private int buscar(char c, int corrimiento, list  abecedario)
{
    int i = 0;
    int posicion = -1;
    while (i < abecedario.Length && posicion == -1)
    {
        if (abecedario[i] == c)
        {
            posicion = i;
        }
        else
        {
            i++;
           
        }

    }
    return posicion;
}

   