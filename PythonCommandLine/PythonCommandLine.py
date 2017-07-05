# coding: utf-8

from datetime import date
hj = date.today()
print (hj)

daysOfMonths = [ 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ]

def isLeapYear(year):
  if (year % 4 == 0 and year % 400 == 0) or (year % 4 == 0 and year % 100 != 0):
    return True
  else:
    return False

def daysBetweenDates(aNasc, mNasc, dNasc, aAtual, mAtual, dAtual):
  listaAnos = []
  qtdeAnos = 0
  diasMeses = 0
  qtdeDias = 0
  diasAnos = 0

  if aAtual > aNasc:
    qtdeAnos = aAtual - aNasc
    a = aNasc
    while a < aAtual:
      listaAnos.append(a)
      a += 1

  if mAtual > mNasc:
    diasMeses = daysOfMonths[mNasc-1] - dNasc
    i = mNasc + 1
    if i > 12:
      i = 1
    if i < mAtual:
      while i < mAtual:
        diasMeses += daysOfMonths[i-1]
        i += 1
    diasMeses += dAtual

  while aAtual > i:
    if isLeapYear(i):
      diasAnos += 1
    i += 1

  qtdeDias = diasMeses + diasAnos

  if qtdeDias == 1:
    return "Você tem 1 dia de idade."
  else:
    return "Você tem " + qtdeDias + " dias de idade."

def leituraDasDatas():
  dtNasc = str(input('Informe sua data de nascimento conforma o exemplo: \"05/06/1989\"\nAtenção! Não se esqueça de digitar as aspas duplas \'\"\"\'!\nData de nascimento: '))
  dtAtual = str(input('Agora informe a data de hoje conforme o exemplo: \"01/07/2017\"\nAtenção! Não se esqueça de digitar as aspas duplas \'\"\"\'!\nData atual: '))
  datas = dtNasc.split("/") #+ dtAtual.split("/"))
  print type(datas)
  return daysBetweenDates(int(datas[2]),int(datas[1]),int(datas[0]),datas[5],datas[4],datas[3])
  #return daysBetweenDates(int(datas[2]),int(datas[1]),int(datas[0]))

print (leituraDasDatas())
