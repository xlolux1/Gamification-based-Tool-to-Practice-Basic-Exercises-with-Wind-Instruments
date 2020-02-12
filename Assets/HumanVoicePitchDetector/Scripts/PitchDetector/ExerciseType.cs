using System;
public class ExerciseType
{

    protected string[] notesPiano = new string[] {"DO","DO#","RE","RE#","MI","FA","FA#","SOL","SOL#","LA","LA#","SI"};
    protected int midiInicial = 24;
    

    public string tunning;
    protected double tunning_number;
    protected int beats;
    protected double miliseconds;

     public ExerciseType (int vel, string tun){
         beats = vel;
         tunning = tun;
         miliseconds = getBeatTime(beats);
         

     }

     private void setTunning(){
         switch (tunning)
      {
          case "FA":
          tunning_number = 1;
          break;
          case "SIB":
              tunning_number = 2;
              break;
          case "MIB":
            tunning_number = 3;
              break;
          case "LAB":
          tunning_number = 4;
              break;
          case "REB":
          tunning_number = 5;
              break;
          case "FA#":
          tunning_number = -6;
              break;
          case "SI":
          tunning_number = -5;
              break;
          case "MI":
          tunning_number = -4;
              break;
          case "LA":
          tunning_number = -3;
              break;
          case "RE":
          tunning_number = -2;
           break;
           case "SOL":
              
          default:
              Console.WriteLine("Default case");
              break;
      }
     }

    public double getBeatTime(double beats){
        return  (1/(beats/60)*1000);
    }
    public double NoteToMidi(string note,int numberScale){
        double midi = 0;
        Console.WriteLine("NOTA" + note);

        for (int i = 0; i < notesPiano.Length; i++){
            if(notesPiano[i].Equals(note)){
                Console.WriteLine("NOTASS" +midiInicial +" "+ i + " "+ numberScale);
               midi =  midiInicial + i + 12 * (numberScale - 1);
            }
        }
        Console.WriteLine(midi);
        return midi;
        

    }
}
