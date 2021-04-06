using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Rat_st : MonoBehaviour
{
    // Крыса на стуле
    [SerializeField] public TextMeshPro text_mesh_st;

    // Крыса слушатель 1
    [SerializeField] public TextMeshPro text_mesh_listener1;

    // Крыса слушатель 2
    [SerializeField] public TextMeshPro text_mesh_listener2;

    // Крыса слушатель 3
    [SerializeField] public TextMeshPro text_mesh_listener3;

    /// <summary>
    /// Паста
    /// </summary>
    public async void Pasta()
    {
        text_mesh_st.text = "Ребята, не стоит вскрывать эту тему";
        await Task.Delay(3000);
        text_mesh_st.text = "Вы молодые, шутливые, вам все легко";
        await Task.Delay(3000);
        text_mesh_st.text = "Это не то";
        await Task.Delay(1500);
        text_mesh_st.text = "Это не Чикатило и даже не архивы спецслужб";
        await Task.Delay(3000);
        text_mesh_st.text = "Сюда лучше не лезть";
        await Task.Delay(2000);
        text_mesh_st.text = "Серьезно, любой из вас будет жалеть";
        await Task.Delay(3000);
        text_mesh_st.text = "Лучше закроем эту тему и забудем, что тут говорилось";
        await Task.Delay(3000);
        text_mesh_st.text = "Я вполне понимаю, что данным сообщением вызову дополнительный интерес, но хочу сразу предостеречь пытливых - стоп";
        await Task.Delay(5000);
        text_mesh_st.text = "Остальные просто не найдут";
        await Task.Delay(2400);
        text_mesh_st.text = null;
        await Task.Delay(3000);
        Joke1();
    }

    /// <summary>
    /// Анекдот первый
    /// </summary>
    public async void Joke1()
    {
        text_mesh_listener1.text = "Поймали Наёмники Сталкера, окунают его в воду и спрашивают:";
        await Task.Delay(3000);
        text_mesh_listener1.text = "- Деньги, бабло, артефакты есть?";
        await Task.Delay(2000);
        text_mesh_listener1.text = "Сталкер:";
        await Task.Delay(1000);
        text_mesh_listener1.text = "- Нет.";
        await Task.Delay(1000);
        text_mesh_listener1.text = "И опять окунают в воду и спрашивают:";
        await Task.Delay(2400);
        text_mesh_listener1.text = "- Деньги, бабло, артефакты есть?";
        await Task.Delay(2000);
        text_mesh_listener1.text = "Сталкер:";
        await Task.Delay(1000);
        text_mesh_listener1.text = "- Да нету, нету!";
        await Task.Delay(2000);
        text_mesh_listener1.text = "А они опять окунают :";
        await Task.Delay(1800);
        text_mesh_listener1.text = "- Деньги, бабло, артефакты есть?";
        await Task.Delay(2000);
        text_mesh_listener1.text = "Ну сталкер не выдержал:";
        await Task.Delay(2000);
        text_mesh_listener1.text = "- Блин, вы либо дольше держите, либо глубже опускайте ! Вода мутная - нихрена не видно!";
        await Task.Delay(3700);
        text_mesh_listener1.text = null;
        await Task.Delay(3000);
        React1();
    }

    /// <summary>
    /// Анекдот второй
    /// </summary>
    public async void Joke2()
    {
        text_mesh_listener3.text = "Заблудился сталкер, идет кричит:";
        await Task.Delay(2300);
        text_mesh_listener3.text = "- ЛЮЮЮДИИИИ!!!! ААУУУ!!! ГДЕ ВЫЫЫЫ??!! ЭЙ КТО НИБУУУУУДЬ!!!! ААУУУУУ!!! ...";
        await Task.Delay(3000);
        text_mesh_listener3.text = "Вдруг сзади его стучат по плечу";
        await Task.Delay(1700);
        text_mesh_listener3.text = "Он оборачивается, а там здоровый такой кровосос, недовольный";
        await Task.Delay(3200);
        text_mesh_listener3.text = "Кровосос:";
        await Task.Delay(1000);
        text_mesh_listener3.text = "Ты чего орешь?!";
        await Task.Delay(2000);
        text_mesh_listener3.text = "Сталкер:";
        await Task.Delay(1000);
        text_mesh_listener3.text = "- Да вот того...  ";
        await Task.Delay(2000);
        text_mesh_listener3.text = "заблудился я...";
        await Task.Delay(2000);
        text_mesh_listener3.text = "думаю может услышит кто...";
        await Task.Delay(2000);
        text_mesh_listener3.text = "Кровосос:";
        await Task.Delay(1000);
        text_mesh_listener3.text = "- Ну я услышал, легче стало?";
        await Task.Delay(3700);
        text_mesh_listener3.text = null;
        await Task.Delay(3000);
        React2();
    }

    /// <summary>
    /// Анекдот третий
    /// </summary>
    public async void Joke3()
    {
        text_mesh_listener3.text = "Идет Сталкер по Зоне";
        await Task.Delay(2600);
        text_mesh_listener3.text = "Видит Монстряка сидит плачет, гоькими слезами обливается";
        await Task.Delay(3200);
        text_mesh_listener3.text = "- Ты че плачешь, Монстряка? - спрашивает";
        await Task.Delay(2440);
        text_mesh_listener3.text = "- Все меня обижают, другие Монстряки обижают, Сталкеры обижают...";
        await Task.Delay(3120);
        text_mesh_listener3.text = "- А хочешь я тебе НАКУ дам?";
        await Task.Delay(2470);
        text_mesh_listener3.text = "- Хочу! - оживилась Монстряка";
        await Task.Delay(2370);
        text_mesh_listener3.text = "Сталкер, снимает автомат и прикладом:";
        await Task.Delay(2630);
        text_mesh_listener3.text = "- НАКА! НАКА! МОНСТРЯКА! ПОЛУЧИ! НАКА!!!";
        await Task.Delay(3680);
        text_mesh_listener3.text = null;
        await Task.Delay(3000);
        React3();
    }

    /// <summary>
    /// Реакция первая
    /// </summary>
    public async void React1()
    {
        text_mesh_listener3.text = "Ну ты дал, чертыла мля внатуре, хааа я отвечаю";
        await Task.Delay(2400);
        text_mesh_listener3.text = null;
        await Task.Delay(3000);
        Joke2();
    }

    /// <summary>
    /// Реакция вторая
    /// </summary>
    public async void React2()
    {
        text_mesh_listener1.text = "Ну ты выдал";
        await Task.Delay(2400);
        text_mesh_listener1.text = null;
        await Task.Delay(3000);
        Joke3();
    }

    /// <summary>
    /// Реакция третья
    /// </summary>
    public async void React3()
    {
        text_mesh_listener2.text = "Так не смешно же";
        await Task.Delay(2400);
        text_mesh_listener2.text = null;
        await Task.Delay(3000);
        Joke1();
    }
}
