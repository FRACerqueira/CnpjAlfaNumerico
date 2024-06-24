using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnpjAlfa
{
    //*************************************************************************************
    // Credito/Autoria do código : Elemar Júnior
    // Ref: https://elemarjr.com/arquivo/validando-cnpj-respeitando-o-garbage-collector
    // Ajuste para Novo modelo de CNPJ
    // https://github.com/FRACerqueira/CnpjAlfaNumerico 
    //*************************************************************************************
    public readonly struct Cnpj
    {
        private readonly string? _value;
        private readonly bool _isvalid;

        static readonly int[] Multiplicador1 = [ 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 ];
        static readonly int[] Multiplicador2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

        public Cnpj(string? value)
        {
            if (value == null)
            {
                return;
            }
            _value = value;
 
            var digitosIdenticos = true;
            var ultimoDigito = 0;
            var posicao = 0;
            var totalDigito1 = 0;
            var totalDigito2 = 0;

            static bool IsValidInput(char c) =>
                    char.IsAsciiDigit(c) || char.IsAsciiLetterUpper(c);

            foreach (var c in value!)
            {
                if (IsValidInput(c))
                {
                    var digito = c - '0';
                    if (posicao != 0 && ultimoDigito != digito)
                    {
                        digitosIdenticos = false;
                    }

                    ultimoDigito = digito;
                    if (posicao < 12)
                    {
                        totalDigito1 += digito * Multiplicador1[posicao];
                        totalDigito2 += digito * Multiplicador2[posicao];
                    }
                    else if (posicao == 12)
                    {
                        var dv1 = (totalDigito1 % 11);
                        dv1 = dv1 < 2
                            ? 0
                            : 11 - dv1;

                        if (digito != dv1)
                        {
                            _isvalid = false;
                            return;
                        }

                        totalDigito2 += dv1 * Multiplicador2[12];
                    }
                    else if (posicao == 13)
                    {
                        var dv2 = (totalDigito2 % 11);

                        dv2 = dv2 < 2
                            ? 0
                            : 11 - dv2;

                        if (digito != dv2)
                        {
                            _isvalid = false;
                            return;
                        }
                    }
                    posicao++;
                }
            }
            _isvalid = (posicao == 14) && !digitosIdenticos;
        }
        public readonly bool IsValid => _isvalid;

        public static implicit operator Cnpj(string? value) => new(value);

        public readonly override string ToString() => _value??string.Empty;
    }
}
