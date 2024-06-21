# Cnpj AlfaNum�rico

A Receita Federal anunciou uma mudan�a no Cadastro Nacional de Pessoas Jur�dicas, introduzindo um novo formato de identifica��o que combinar� n�meros e letras (CNPJ Alfanum�rico), conforme a Nota T�cnica COCAD/SUARA/RFB n� 49/2024.

![](./Images/cnpj_de_para.png)

### A f�rmula de c�lculo do d�gito verificador do CNPJ Alfanum�rico n�o muda: foi mantido o c�lculo pelo m�dulo 11.


Por�m, para garantir a utiliza��o dos atuais n�meros do CNPJ (tipo num�rico), ser� necess�ria a altera��o do modo como se calcula o d�gito verificador pelo m�dulo 11. Ser�o utilizados, no c�lculo do m�dulo 11, os valores relativos a letras mai�sculas lastreadas na tabela denominada c�digo ASCII, como solu��o para unificar a representa��o de caracteres alfanum�ricos. 

Na rotina de c�lculo do D�gito Verificador (DV) no CNPJ, **ser�o substitu�dos os valores num�ricos e alfanum�ricos pelo valor decimal correspondente ao c�digo constante na tabela ASCII** e dele subtra�do o valor 48. Desta forma os caracteres num�ricos continuar�o com os mesmos montantes.

Os caracteres alfanum�ricos ter�o os seguintes valores: **A=17, B=18, C=19�** e assim sucessivamente. Esta defini��o permitir� que o atual n�mero do CNPJ tenha o mesmo c�lculo do seu d�gito verificador quando os sistemas iniciarem a identifica��o alfanum�rica.

O desenho abaixo mostra a correspond�ncia entre letras e n�meros e seus 
respectivos valores na tabela ASCII:

![](./Images/ascii.png)

# Creditos

Todo o c�digo apresentado � de autoria de ao Elemar J�nior! apenas fizemos uma pequena altera��o para contemplar os tipos letras (A~Z) 

ref: https://elemarjr.com/arquivo/validando-cnpj-respeitando-o-garbage-collector

# Resultados para 3.000.000 valida��es
![](./Images/capturateste.png)