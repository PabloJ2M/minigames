public class Clock : Timer
{
    protected override string Format()
    {
        int minutos = (int)_current / 60;
        int segundos = (int)_current % 60;

        return string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}