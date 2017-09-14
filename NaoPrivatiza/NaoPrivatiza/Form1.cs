using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Mail;

namespace NaoPrivatiza
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private String[] emails;
        private int smtpPort = 25;
        private String smtpHost = "";
        private bool smtpSsl = true;

        public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            comboBox1.SelectedIndex = 0;
            SendMessage(textBox1.Handle, EM_SETCUEBANNER, 0, "Digite aqui o seu nome");
            SendMessage(textBox2.Handle, EM_SETCUEBANNER, 0, "Digite aqui o seu email do gmail");
            SendMessage(textBox3.Handle, EM_SETCUEBANNER, 0, "Digite aqui sua senha do email");

//*
            emails = new String[11];
            emails[0] = "dep.abelmesquitajr@camara.leg.br; dep.adailcarneiro@camara.leg.br; dep.adalbertocavalcanti@camara.leg.br; dep.adelmocarneiroleao@camara.leg.br; dep.adelsonbarreto@camara.leg.br; dep.ademircamilo@camara.leg.br; dep.adiltonsachetti@camara.leg.br; dep.afonsoflorence@camara.leg.br; dep.afonsohamm@camara.leg.br; dep.afonsomotta@camara.leg.br; dep.aguinaldoribeiro@camara.leg.br; dep.alanrick@camara.leg.br; dep.albertofilho@camara.leg.br; dep.albertofraga@camara.leg.br; dep.alceumoreira@camara.leg.br; dep.alessandromolon@camara.leg.br; dep.alexcanziani@camara.leg.br; dep.alexmanente@camara.leg.br; dep.alexandrebaldy@camara.leg.br; dep.alexandreleite@camara.leg.br; dep.alexandreserfiotis@camara.leg.br; dep.alexandrevalle@camara.leg.br; dep.alfredokaefer@camara.leg.br; dep.alfredonascimento@camara.leg.br; dep.aliceportugal@camara.leg.br; dep.alielmachado@camara.leg.br; dep.altineucortes@camara.leg.br; dep.aluisiomendes@camara.leg.br; dep.anaperugini@camara.leg.br; dep.andreabdon@camara.leg.br; dep.andreamaral@camara.leg.br; dep.andredepaula@camara.leg.br; dep.andrefigueiredo@camara.leg.br; dep.andrefufuca@camara.leg.br; dep.andremoura@camara.leg.br; dep.andressanchez@camara.leg.br; dep.angelim@camara.leg.br; dep.anibalgomes@camara.leg.br; dep.antoniobrito@camara.leg.br; dep.antoniobulhoes@camara.leg.br; dep.antoniojacome@camara.leg.br; dep.ariostoholanda@camara.leg.br; dep.arlindochinaglia@camara.leg.br; dep.arnaldofariadesa@camara.leg.br; dep.arnaldojordy@camara.leg.br; dep.aroldedeoliveira@camara.leg.br; dep.arthurlira@camara.leg.br; dep.arthuroliveiramaia@camara.leg.br; dep.arthurvirgiliobisneto@camara.leg.br";
            emails[1] = "dep.assiscarvalho@camara.leg.br; dep.assisdocouto@camara.leg.br; dep.assismelo@camara.leg.br; dep.atilalins@camara.leg.br; dep.atilalira@camara.leg.br; dep.augustocarvalho@camara.leg.br; dep.augustocoutinho@camara.leg.br; dep.aureo@camara.leg.br; dep.bacelar@camara.leg.br; dep.bacelar@camara.leg.br; dep.bebeto@camara.leg.br; dep.beneditadasilva@camara.leg.br; dep.benitogama@camara.leg.br; dep.benjaminmaranhao@camara.leg.br; dep.betinhogomes@camara.leg.br; dep.betofaro@camara.leg.br; dep.betomansur@camara.leg.br; dep.betorosado@camara.leg.br; dep.betosalame@camara.leg.br; dep.bilacpinto@camara.leg.br; dep.bohngass@camara.leg.br; dep.bonifaciodeandrada@camara.leg.br; dep.brunafurlan@camara.leg.br; dep.brunny@camara.leg.br; dep.cabodaciolo@camara.leg.br; dep.cabosabino@camara.leg.br; dep.cabucuborges@camara.leg.br; dep.cacaleao@camara.leg.br; dep.caetano@camara.leg.br;; dep.caionarcio@camara.leg.br; dep.cajarnardes@camara.leg.br; dep.capitaoaugusto@camara.leg.br; dep.carlosandrade@camara.leg.br; dep.carlosbezerra@camara.leg.br; dep.carloseduardocadoca@camara.leg.br; dep.carlosgomes@camara.leg.br; dep.carloshenriquegaguim@camara.leg.br; dep.carlosmanato@camara.leg.br; dep.carlosmarun@camara.leg.br; dep.carlosmelles@camara.leg.br; dep.carlossampaio@camara.leg.br;;; dep.carloszarattini@camara.leg.br; dep.carmenzanotto@camara.leg.br; dep.celiosilveira@camara.leg.br; dep.celsojacob@camara.leg.br; dep.celsomaldaner@camara.leg.br; dep.celsopansera@camara.leg.br";
            emails[2] = "dep.celsorussomanno@camara.leg.br; dep.cesarhalum@camara.leg.br; dep.cesarmessias@camara.leg.br; dep.cesarsouza@camara.leg.br; dep.chicoalencar@camara.leg.br; dep.chicodangelo@camara.leg.br; dep.chicolopes@camara.leg.br; dep.christianedesouzayared@camara.leg.br; dep.ciceroalmeida@camara.leg.br; dep.claudiocajado@camara.leg.br; dep.cleberverde@camara.leg.br; dep.conceicaosampaio@camara.leg.br; dep.covattifilho@camara.leg.br; dep.creuzapereira@camara.leg.br; dep.cristianebrasil@camara.leg.br; dep.dagobertonogueira@camara.leg.br; dep.damiaofeliciano@camara.leg.br; dep.daminapereira@camara.leg.br; dep.danielalmeida@camara.leg.br; dep.danielcoelho@camara.leg.br; dep.danielvilela@camara.leg.br; dep.danilocabral@camara.leg.br; dep.daniloforte@camara.leg.br; dep.danrleidedeushinterholz@camara.leg.br; dep.darcisioperondi@camara.leg.br; dep.davidsonmagalhaes@camara.leg.br; dep.deciolima@camara.leg.br; dep.dejorgepatricio@camara.leg.br; dep.delegadoedermauro@camara.leg.br; dep.delegadoedsonmoreira@camara.leg.br; dep.delegadofrancischini@camara.leg.br; dep.delegadowaldir@camara.leg.br; dep.deley@camara.leg.br; dep.deoclidesmacedo@camara.leg.br; dep.diegoandrade@camara.leg.br; dep.diegogarcia@camara.leg.br; dep.dilceusperafico@camara.leg.br; dep.dimasfabiano@camara.leg.br; dep.domingosneto@camara.leg.br; dep.domingossavio@camara.leg.br; dep.dr.jorgesilva@camara.leg.br; dep.dr.sinvalmalheiros@camara.leg.br; dep.dulcemiranda@camara.leg.br; dep.ediolopes@camara.leg.br; dep.edmararruda@camara.leg.br; dep.edmilsonrodrigues@camara.leg.br; dep.eduardobarbosa@camara.leg.br; dep.eduardobolsonaro@camara.leg.br; dep.eduardocury@camara.leg.br";
            emails[3] = "dep.eduardodafonte@camara.leg; dep.efraimfilho@camara.leg.br; dep.elcionebarbalho@camara.leg.br; dep.elicorreafilho@camara.leg.br; dep.elizeudionizio@camara.leg.br; dep.elizianegama@camara.leg.br; dep.elmarnascimento@camara.leg.br; dep.enioverri@camara.leg.br; dep.erikakokay@camara.leg.br; dep.eriveltonsantana@camara.leg.br; dep.erosbiondini@camara.leg.br; dep.esperidiaoamin@camara.leg.br; dep.evairvieirademelo@camara.leg.br; dep.evandrogussi@camara.leg.br; dep.evandroroman@camara.leg.br; dep.expeditonetto@camara.leg.br; dep.ezequielfonseca@camara.leg.br; dep.ezequielteixeira@camara.leg.br; dep.fabiofaria@camara.leg.br; dep.fabiogarcia@camara.leg.br; dep.fabiomitidieri@camara.leg.br; dep.fabioramalho@camara.leg.br; dep.fabioreis@camara.leg.br; dep.fabiosousa@camara.leg.br; dep.faustopinato@camara.leg.br; dep.felipebornier@camara.leg.br; dep.felipemaia@camara.leg.br; dep.felixmendoncajunior@camara.leg.br; dep.fernandomonteiro@camara.leg.br; dep.flaviamorais@camara.leg.br; dep.flavianomelo@camara.leg.br; dep.flavinho@camara.leg.br; dep.franciscochapadinha@camara.leg.br; dep.franciscofloriano@camara.leg.br; dep.franklin@camara.leg.br; dep.gabrielguimaraes@camara.leg.br; dep.geneciasnoronha@camara.leg.br; dep.georgehilton@camara.leg.br; dep.geovaniadesa@camara.leg.br; dep.geraldoresende@camara.leg.br; dep.giacobo@camara.leg.br; dep.gilbertonascimento@camara.leg.br; dep.giovanicherini@camara.leg.br; dep.giuseppevecci@camara.leg.br; dep.givaldocarimbao@camara.leg.br; dep.givaldovieira@camara.leg.br; dep.glauberbraga@camara.leg.br; dep.gonzagapatriota@camara.leg.br; dep.goretepereira@camara.leg.br";
            emails[4] = "dep.goulart@camara.leg.br; dep.guilhermecoelho@camara.leg.br; dep.guilhermemussi@camara.leg.br; dep.heitorschuch@camara.leg.br; dep.heldersalomao@camara.leg.br; dep.helioleite@camara.leg.br; dep.henriquefontana@camara.leg.br; dep.heraclitofortes@camara.leg.br; dep.herculanopassos@camara.leg.br; dep.hermesparcianello@camara.leg.br; dep.heulercruvinel@camara.leg.br; dep.hildorocha@camara.leg.br; dep.hirangoncalves@camara.leg.br; dep.hissaabrahao@camara.leg.br; dep.hugoleal@camara.leg.br; dep.hugomotta@camara.leg.br; dep.iracemaportella@camara.leg.br; dep.irajaabreu@camara.leg.br; dep.irmaolazaro@camara.leg.br; dep.ivanvalente@camara.leg.br; dep.izalcilucas@camara.leg.br; dep.izaquesilva@camara.leg.br; dep.jaimemartins@camara.leg.br; dep.jairbolsonaro@camara.leg.br; dep.jandirafeghali@camara.leg.br; dep.janetecapiberibe@camara.leg.br; dep.jarbasvasconcelos@camara.leg.br; dep.jeanwyllys@camara.leg.br; dep.jeffersoncampos@camara.leg.br; dep.jeronimogoergen@camara.leg.br; dep.jessicasales@camara.leg.br; dep.jhc@camara.leg.br; dep.jhonatandejesus@camara.leg.br; dep.jomoraes@camara.leg.br; dep.joaoarruda@camara.leg.br; dep.joaocampos@camara.leg.br; dep.joaocarlosbacelar@camara.leg.br; dep.joaodaniel@camara.leg.br; dep.joaoderly@camara.leg.br; dep.joaofernandocoutinho@camara.leg.br; dep.joaogualberto@camara.leg.br; dep.joaomarcelosouza@camara.leg.br; dep.joaopaulokleinubing@camara.leg.br; dep.joaopaulopapa@camara.leg.br; dep.joaorodrigues@camara.leg.br; dep.joaquimpassarinho@camara.leg.br; dep.jonesmartins@camara.leg.br; dep.jonymarcos@camara.leg.br";
            emails[5] = "dep.jorgeboeira@camara.leg.br; dep.jorgecortereal@camara.leg.br; dep.jorgesolla@camara.leg.br; dep.jorgetadeumudalen@camara.leg.br; dep.jorginhomello@camara.leg.br; dep.joseairtoncirilo@camara.leg.br; dep.josecarlosaleluia@camara.leg.br; dep.josecarlosaraujo@camara.leg.br; dep.josefogaca@camara.leg.br; dep.joseguimaraes@camara.leg.br; dep.josementor@camara.leg.br; dep.josenunes@camara.leg.br; dep.joseotaviogermano@camara.leg.br; dep.josepriante@camara.leg.br; dep.josereinaldo@camara.leg.br; dep.josestedile@camara.leg.br; dep.josinunes@camara.leg.br; dep.josuebengtson@camara.leg.br; dep.jovairarantes@camara.leg.br; dep.joziaraujo@camara.leg.br; dep.juliamarinho@camara.leg.br; dep.juliocesar@camara.leg.br; dep.juliodelgado@camara.leg.br; dep.juliolopes@camara.leg.br; dep.juniormarreca@camara.leg.br; dep.juscelinofilho@camara.leg.br; dep.jutahyjunior@camara.leg.br; dep.keikoota@camara.leg.br; dep.laerciooliveira@camara.leg.br; dep.laertebessa@camara.leg.br; dep.laudiviocarvalho@camara.leg.br; dep.lauracarneiro@camara.leg.br; dep.lazarobotelho@camara.leg.br; dep.leandre@camara.leg.br; dep.lelocoimbra@camara.leg.br; dep.leodebrito@camara.leg.br; dep.leonardomonteiro@camara.leg.br; dep.leonardoquintao@camara.leg.br; dep.leonidascristino@camara.leg.br; dep.leopoldomeyer@camara.leg.br; dep.lincolnportela@camara.leg.br; dep.lindomargarcon@camara.leg.br; dep.lobbeneto@camara.leg.br; dep.luanacosta@camara.leg.br; dep.lucasvergilio@camara.leg.br; dep.lucianasantos@camara.leg.br; dep.lucianobivar@camara.leg.br; dep.lucianoducci@camara.leg.br; dep.luciomosquini@camara.leg.br";
            emails[6] = "dep.luciovale@camara.leg.br; dep.luciovieiralima@camara.leg.br; dep.luiscarlosheinze@camara.leg.br; dep.luistibe@camara.leg.br; dep.luizcarloshauly@camara.leg.br; dep.luizcarlosramos@camara.leg.br; dep.luizclaudio@camara.leg.br; dep.luizcouto@camara.leg.br; dep.luizfernandofaria@camara.leg.br; dep.luizlaurofilho@camara.leg.br; dep.luiznishimori@camara.leg.br; dep.luizsergio@camara.leg.br; dep.luizaerundina@camara.leg.br; dep.luiziannelins@camara.leg.br; dep.macedo@camara.leg.br; dep.magdamofatto@camara.leg.br; dep.maiafilho@camara.leg.br; dep.majorolimpio@camara.leg.br; dep.mandetta@camara.leg.br; dep.maragabrilli@camara.leg.br; dep.marceloaguiar@camara.leg.br; dep.marceloalvaroantonio@camara.leg.br; dep.marceloaro@camara.leg.br; dep.marcelocastro@camara.leg.br; dep.marcelodelaroli@camara.leg.br; dep.marcelomatos@camara.leg.br; dep.marcelosquassoni@camara.leg.br; dep.marcioalvino@camara.leg.br; dep.marciomarinho@camara.leg.br; dep.marcoantoniocabral@camara.leg.br; dep.marcomaia@camara.leg.br; dep.marcotebaldi@camara.leg.br; dep.marcon@camara.leg.br; dep.marcosabrao@camara.leg.br; dep.marcosmontes@camara.leg.br; dep.marcosreategui@camara.leg.br; dep.marcosrogerio@camara.leg.br; dep.marcossoares@camara.leg.br; dep.marcuspestana@camara.leg.br; dep.marcusvicente@camara.leg.br; dep.margaridasalomao@camara.leg.br; dep.mariadorosario@camara.leg.br; dep.mariahelena@camara.leg.br; dep.marianacarvalho@camara.leg.br; dep.marinaldorosendo@camara.leg.br; dep.marioheringer@camara.leg.br; dep.marionegromontejr@camara.leg.br; dep.maurolopes@camara.leg.br; dep.mauromariani@camara.leg.br";
            emails[7] = "dep.mauropereira@camara.leg.br; dep.miguelhaddad@camara.leg.br; dep.miguellombardi@camara.leg.br; dep.miltonmonti@camara.leg.br; dep.miroteixeira@camara.leg.br; dep.misaelvarella@camara.leg.br; dep.missionariojoseolimpio@camara.leg.br; dep.moisesdiniz@camara.leg.br; dep.mosesrodrigues@camara.leg.br; dep.nelsonmarquezelli@camara.leg.br; dep.nelsonmeurer@camara.leg.br; dep.nelsonpadovani@camara.leg.br; dep.nelsonpellegrino@camara.leg.br; dep.newtoncardosojr@camara.leg.br; dep.nilsonleitao@camara.leg.br; dep.nilsonpinto@camara.leg.br; dep.niltotatto@camara.leg.br; dep.niltoncapixaba@camara.leg.br; dep.nivaldoalbuquerque@camara.leg.br; dep.normaayub@camara.leg.br; dep.odoricomonteiro@camara.leg.br; dep.onyxlorenzoni@camara.leg.br; dep.orlandosilva@camara.leg.br; dep.osmarbertoldi@camara.leg.br; dep.osmarserraglio@camara.leg.br; dep.otavioleite@camara.leg.br; dep.padrejoao@camara.leg.br; dep.paeslandim@camara.leg.br; dep.pastoreurico@camara.leg.br; dep.pastorlucianobraga@camara.leg.br; dep.patrusananias@camara.leg.br; dep.pauderneyavelino@camara.leg.br; dep.paulao@camara.leg.br;; dep.pauloabiackel@camara.leg.br; dep.pauloazi@camara.leg.br; dep.paulofeijo@camara.leg.br; dep.paulofoletto@camara.leg.br; dep.paulofreire@camara.leg.br; dep.paulohenriquelustosa@camara.leg.br; dep.paulomagalhaes@camara.leg.br; dep.paulomaluf@camara.leg.br; dep.paulopereiradasilva@camara.leg.br; dep.paulopimenta@camara.leg.br; dep.pauloteixeira@camara.leg.br; dep.pedrochaves@camara.leg.br; dep.pedrocunhalima@camara.leg.br; dep.pedrofernandes@camara.leg.br; dep.pedropaulo@camara.leg.br; dep.pedrouczai@camara.leg.br";
            emails[8] = "dep.pedrovilela@camara.leg.br; dep.pepevargas@camara.leg.br; dep.pollyanagama@camara.leg.br; dep.pompeodemattos@camara.leg.br; dep.pr.marcofeliciano@camara.leg.br; dep.professorvictoriogalli@camara.leg.br; dep.professoramarcivania@camara.leg.br; dep.rafaelmotta@camara.leg.br; dep.raimundogomesdematos@camara.leg.br; dep.raquelmuniz@camara.leg.br; dep.reginaldolopes@camara.leg.br; dep.reinholdstephanes@camara.leg.br; dep.remidiomonai@camara.leg.br; dep.renataabreu@camara.leg.br; dep.renatoandrade@camara.leg.br; dep.renatomolling@camara.leg.br; dep.renzobraz@camara.leg.br; dep.ricardoizar@camara.leg.br; dep.ricardoteobaldo@camara.leg.br; dep.ricardotripoli@camara.leg.br; dep.robertoalves@camara.leg.br; dep.robertobalestra@camara.leg.br; dep.robertobritto@camara.leg.br; dep.robertodelucena@camara.leg.br; dep.robertofreire@camara.leg.br; dep.robertogoes@camara.leg.br; dep.robertosales@camara.leg.br; dep.robinsonalmeida@camara.leg.br; dep.rocha@camara.leg.br; dep.rodrigodecastro@camara.leg.br; dep.rodrigomaia@camara.leg.br; dep.rodrigomartins@camara.leg.br; dep.rodrigopacheco@camara.leg.br; dep.rogeriomarinho@camara.leg.br; dep.rogeriopeninhamendonca@camara.leg.br; dep.rogeriorosso@camara.leg.br; dep.rogeriosilva@camara.leg.br; dep.romulogouveia@camara.leg.br; dep.ronaldobenedet@camara.leg.br; dep.ronaldocarletto@camara.leg.br; dep.ronaldofonseca@camara.leg.br; dep.ronaldolessa@camara.leg.br; dep.ronaldomartins@camara.leg.br; dep.roneynemer@camara.leg.br; dep.rosangelagomes@camara.leg.br; dep.rosinhadaadefal@camara.leg.br; dep.rubensbueno@camara.leg.br; dep.rubensotoni@camara.leg.br; dep.rubenspereirajunior@camara.leg.br";
            emails[9] = "dep.sabinocastelobranco@camara.leg.br; dep.saguasmoraes@camara.leg.br; dep.sandroalex@camara.leg.br; dep.saraivafelipe@camara.leg.br; dep.sergiobrito@camara.leg.br; dep.sergiomoraes@camara.leg.br; dep.sergioreis@camara.leg.br; dep.sergiosouza@camara.leg.br; dep.sergiovidigal@camara.leg.br; dep.sergiozveiter@camara.leg.br; dep.severinoninho@camara.leg.br; dep.sheridan@camara.leg.br; dep.silascamara@camara.leg.br; dep.silasfreire@camara.leg.br; dep.silviocosta@camara.leg.br; dep.silviotorres@camara.leg.br; dep.simaosessim@camara.leg.br; dep.simonemorgado@camara.leg.br; dep.sorayasantos@camara.leg.br; dep.sostenescavalcante@camara.leg.br; dep.stefanoaguiar@camara.leg.br; dep.subtenentegonzaga@camara.leg.br; dep.tadeualencar@camara.leg.br; dep.takayama@camara.leg.br; dep.tenentelucio@camara.leg.br; dep.terezacristina@camara.leg.br; dep.thiagopeixoto@camara.leg.br; dep.tiririca@camara.leg.br; dep.toninhopinheiro@camara.leg.br; dep.toninhowandscheer@camara.leg.br; dep.ulduricojunior@camara.leg.br; dep.vaidonoliveira@camara.leg.br; dep.valadaresfilho@camara.leg.br; dep.valdircolatto@camara.leg.br; dep.valmirassuncao@camara.leg.br; dep.valmirprascidelli@camara.leg.br; dep.vanderloubet@camara.leg.br; dep.vanderleimacris@camara.leg.br; dep.venezianovitaldorego@camara.leg.br; dep.vicentecandido@camara.leg.br; dep.vicentinho@camara.leg.br; dep.vicentinhojunior@camara.leg.br; dep.victormendes@camara.leg.br; dep.viniciuscarvalho@camara.leg.br; dep.viniciusgurgel@camara.leg.br; dep.vitorlippi@camara.leg.br; dep.vitorvalim@camara.leg.br; dep.wadihdamous@camara.leg.br; dep.waldenorpereira@camara.leg.br";
            emails[10] = "dep.waldirmaranhao@camara.leg.br; dep.walneyrocha@camara.leg.br; dep.walteralves@camara.leg.br; dep.walterihoshi@camara.leg.br; dep.welitonprado@camara.leg.br; dep.wellingtonroberto@camara.leg.br; dep.wevertonrocha@camara.leg.br; dep.wilsonbeserra@camara.leg.br; dep.wilsonfilho@camara.leg.br; dep.wladimircosta@camara.leg.br; dep.wolneyqueiroz@camara.leg.br; dep.yedacrusius@camara.leg.br; dep.zeaugustonalin@camara.leg.br; dep.zecarlos@camara.leg.br; dep.zegeraldo@camara.leg.br; dep.zesilva@camara.leg.br; dep.zecacavalcanti@camara.leg.br; dep.zecadirceu@camara.leg.br; dep.zecadopt@camara.leg.br; dep.zenaidemaia@camara.leg.br";
 //*/
/*
            emails = new String[3];
            emails[0] = "jokerfvd@gmail.com; fduval@cepel.br";
            emails[1] = "luisrenatosilva@gmail.com; luisrs@cepel.br";
            emails[2] = "brunolcf@gmail.com; brunocf@cepel.br";
 */ 

            progressBar1.Step = 1;
            progressBar1.Maximum = emails.Length;
        }

        private bool validaEmail()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(textBox2.Text);
                return addr.Address == textBox2.Text;
            }
            catch
            {
                return false;
            }
        }

        private bool setSmttp()
        {
            if (textBox2.Text.Contains("gmail")){
                smtpPort = 587;
                smtpHost = "smtp.gmail.com";
            }
/*
            else if (textBox2.Text.Contains("yahoo")){
                smtpPort = 465;
                smtpHost = "smtp.mail.yahoo.com";
            }
 */ 
            else
                return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (textBox1.Text == ""){
                MessageBox.Show("Digite o seu nome!");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == ""){
                MessageBox.Show("Digite o seu email!");
                textBox2.Focus();
                return;
            }
            if (textBox3.Text == ""){
                MessageBox.Show("Digite a sua senha!");
                textBox3.Focus();
                return;
            }
            if (!validaEmail())
            {
                MessageBox.Show("O email digitado é inválido!");
                textBox2.Focus();
                return;
            }
            if (!setSmttp())
            {
                MessageBox.Show("Nao consigo enviar por esse remetente, favor escolher um email do gmail!");
                textBox2.Focus();
                return;
            }

            //preprando para enviar o email
            MailAddress from = new MailAddress(textBox2.Text, textBox1.Text);
            //var to = new MailAddress();
            MailMessage message = new MailMessage();
            message.From = from;
            message.Body = richTextBox1.Text+textBox1.Text;//email com o nome
            message.Subject = comboBox1.Text;
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            SmtpClient client = new SmtpClient();
            client.Host = smtpHost;
            client.Port = smtpPort;
            client.EnableSsl = smtpSsl;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(textBox2.Text,textBox3.Text);

            //client.Credentials = CredentialCache.DefaultCredentials; //para o servidor preencher

            bool first = true;
            label6.Visible = true;
            label6.Update();
            try{
                foreach (String lista in emails)
                {
                    if (first)
                        first = false;
                    else //esperando 5s para enviar o proximo pois pode dar algum erro enviando muitos de uma vez.
                        System.Threading.Thread.Sleep(5000);
                    foreach(String email in lista.Split(';'))
                        message.CC.Add(new MailAddress(email));
                    client.Send(message);
                    for (int i = message.CC.Count - 1; i >= 0;i-- )
                        message.CC.RemoveAt(i);
                    progressBar1.PerformStep();
                }
            }
            catch (Exception ex){
                MessageBox.Show("Houve um problema! =( : "+ex.ToString());
            }
            label6.Visible = false;
        }
    }
}
