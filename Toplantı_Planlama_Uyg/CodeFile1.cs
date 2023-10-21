using System;
using System.Drawing;
using System.Windows.Forms;

public class MeetingForm : Form
{
    private TextBox titleTextBox;
    private DateTimePicker dateTimePicker;
    private TextBox descriptionTextBox;
    private Button createButton;
    private Button shareCodeButton;

    private Meeting meeting;

    public MeetingForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Form öğelerini oluşturun ve yerleştirin

        titleTextBox = new TextBox();
        dateTimePicker = new DateTimePicker();
        descriptionTextBox = new TextBox();
        createButton = new Button();
        shareCodeButton = new Button();

        // Form öğelerinin özelliklerini ayarlayın

        titleTextBox.Location = new Point(10, 10);
        titleTextBox.Size = new Size(200, 20);

        dateTimePicker.Location = new Point(10, 40);
        dateTimePicker.Size = new Size(200, 20);

        descriptionTextBox.Location = new Point(10, 70);
        descriptionTextBox.Size = new Size(200, 60);

        createButton.Location = new Point(10, 140);
        createButton.Size = new Size(90, 30);
        createButton.Text = "Toplantı Oluştur";
        createButton.Click += CreateButton_Click;

        shareCodeButton.Location = new Point(110, 140);
        shareCodeButton.Size = new Size(90, 30);
        shareCodeButton.Text = "Kodu Paylaş";
        shareCodeButton.Click += ShareCodeButton_Click;

        // Form'a öğeleri ekleyin

        Controls.Add(titleTextBox);
        Controls.Add(dateTimePicker);
        Controls.Add(descriptionTextBox);
        Controls.Add(createButton);
        Controls.Add(shareCodeButton);
    }

    private void CreateButton_Click(object sender, EventArgs e)
    {
        // Kullanıcının girdiği bilgileri kullanarak toplantıyı oluşturun
        meeting = new Meeting();
        meeting.Title = titleTextBox.Text;
        meeting.Date = dateTimePicker.Value;
        meeting.Description = descriptionTextBox.Text;

        // Toplantı oluşturulduğunda diğer işlevselliği burada ekleyebilirsiniz
        // Örneğin, toplantı zamanlarını seçme işlevselliğini burada başlatabilirsiniz.
    }

    private void ShareCodeButton_Click(object sender, EventArgs e)
    {
        if (meeting == null)
        {
            MessageBox.Show("Önce toplantıyı oluşturun.");
            return;
        }

        // Toplantı kodunu kullanıcıya gösterme işlevselliği burada yer alır
        string code = meeting.GenerateMeetingCode();
        MessageBox.Show($"Toplantı Kodu: {code}");
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        MeetingForm meetingForm = new MeetingForm();
        Application.Run(meetingForm);
    }
}

public class Meeting
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public string GenerateMeetingCode()
    {
        // Basitçe, toplantı başlığı ve tarihini kullanarak bir kod üretiyoruz.
        return $"{Title}_{Date.ToString("yyyyMMddHHmm")}";
    }
}
