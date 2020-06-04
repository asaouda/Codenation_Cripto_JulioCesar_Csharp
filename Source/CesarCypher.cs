using System;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        const int _qtdeCasas = 3;
        char[] _alfabeto = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public string Crypt(string message)
        {
            
            if (message == null)
            {
                throw new ArgumentNullException ("Mensagem está Nula.");
            }
            else if (message == "")
            {
                return "";
            }
            else 
            {
                message = message.ToLower();
                char invalido = GetTextoValido(message);
                if (invalido!=' ')
                {
                    throw new ArgumentOutOfRangeException(invalido.ToString(), "Caracter inválido.");
                }
                
            }

            return GetTextoCifrado(message);
        }

        public string Decrypt(string cryptedMessage)
        {
            
            if (cryptedMessage == null)
            {
                throw new ArgumentNullException("Mensagem está Nula.");
            }
            else if (cryptedMessage == "")
            {
                return "";
            }
            else 
            {
                cryptedMessage = cryptedMessage.ToLower();
                char invalido = GetTextoValido(cryptedMessage);
                if (invalido != ' ')
                {
                    throw new ArgumentOutOfRangeException(invalido.ToString(),"Caracter inválido.");
                }
            }

            return GetTextoDecifrado(cryptedMessage);
        }

        public char GetTextoValido(string message)
        {
            var texto = message.ToString();
            for (int index = 0; index < texto.Length; index++)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (_alfabeto[i] == texto[index])
                    {
                        return ' ';
                    }
                }


                if (texto[index] == ' ' || Char.IsNumber(texto[index]))
                {
                    return ' ';
                }
                else
                {
                    return texto[index];
                }
            }
            return ' ';
        }

        public string GetTextoDecifrado(string textoCriptografado)
        {
            string textoDecifrado = "";
            var chars = textoCriptografado.ToCharArray();

            for (int index = 0; index < chars.Length; index++)
            {
                char charDescriptografado = GetLetraDecifrada(chars[index]);
                textoDecifrado = textoDecifrado + charDescriptografado;
            }
            return textoDecifrado;
        }
        public string GetTextoCifrado(string texto)
        {
            string textoCifrado = "";
            var chars = texto.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char charCriptografado = GetLetraCifrada(chars[i]);
                textoCifrado = textoCifrado + charCriptografado;
            }
            return textoCifrado;
        }
        public char GetLetraDecifrada(char letraCifrada)
        { 
            for (int i = 0; i < 26; i++)
            {
                if (_alfabeto[i] == letraCifrada)
                {
                    int index = i - _qtdeCasas;
                    if (index < 0)
                    {
                        index+=_alfabeto.Length;
                    }
                    return _alfabeto[index];
                }
            }
            return letraCifrada;
        }

        public char GetLetraCifrada(char letra)
        {
            for (int i = 0; i < 26; i++)
            {
                if (_alfabeto[i] == letra)
                {
                    int index = i + _qtdeCasas;
                    if (index >25)
                    {
                        index -= _alfabeto.Length ;
                    }
                    return _alfabeto[index];
                }
            }
            return letra;
        }

        
    }
}
