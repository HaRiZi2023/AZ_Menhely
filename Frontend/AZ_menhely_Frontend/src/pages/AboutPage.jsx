import { Carousel} from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import image0 from '../assets/logo0.jpg';
import image1 from '../assets/front1.jpg';
import image2 from '../assets/front2.jpg';
import image3 from '../assets/front3a.jpg';
import image4 from '../assets/front4.jpg';
import aboutUsImage from '../assets/front5.jpg';
import missionImage from '../assets/front6.jpg';
import styles from '../styles/AboutPage.module.css';
function AboutPage() {


  return (
    <div className={styles['about-page']}>
      <header className={styles['about-page-header']}>
        <Carousel className={styles['carousel-card']}>
          <Carousel.Item>
            <div className={styles['carousel-image-container']}>
              <img
                className={styles['carousel-image']}
                src={image0}
                alt="logo0 slide"
              />
            </div>
            <Carousel.Caption className={styles['caption-text']}>
              <h2><strong>A - Z</strong> menhely : Otthon minden állatnak</h2>
            </Carousel.Caption>
          </Carousel.Item>
          <Carousel.Item>
            <div className={styles['carousel-image-container']}>
              <img
                className={styles['carousel-image']}
                src={image1}
                alt="First slide"
              />
            </div>
            <Carousel.Caption className={styles['caption-text']}>
              <h3>Barátok : Egy elveszett kutyus újra otthonra lel</h3>
            </Carousel.Caption>
          </Carousel.Item>
          <Carousel.Item>
            <div className={styles['carousel-image-container']}>
              <img
                className={styles['carousel-image']}
                src={image2}
                alt="Second slide"
              />
            </div>
            <Carousel.Caption className={styles['caption-text']}>
              <h3>Gyógyulás Kezében : Állatorvosunk mindig a segítségedre van</h3>
            </Carousel.Caption>
          </Carousel.Item>
          <Carousel.Item>
            <div className={styles['carousel-image-container']}>
              <img
                className={styles['carousel-image']}
                src={image3}
                alt="Third slide"
              />
            </div>
            <Carousel.Caption className={styles['caption-text']}>
              <h3>Második Esély : Az utcán élő kutyák számára is van remény</h3>
            </Carousel.Caption>
          </Carousel.Item>
          <Carousel.Item>
            <div className={styles['carousel-image-container']}>
              <img
                className={styles['carousel-image']}
                src={image4}
                alt="Fourth slide"
              />
            </div>
            <Carousel.Caption className={styles['caption-text']}>
              <h3 >Családi Örömök : Egy új taggal gazdagabb család</h3>
            </Carousel.Caption>
          </Carousel.Item>
        </Carousel>
      </header>
      <main>
        <section className="py-5">
          <div className={styles['container2']}>
            <h2>Azért jöttünk létre . . .</h2>
            <p>Szeretnénk minnél több állaton segíteni!Őket is úgyan olyan jogok illetik meg ,csak mert nem tudnak beszélni ŐK is éreznek.Sajnos az emberek elfelejtik hogy az állatoknak is vannak érzéseik és nekik is tud fájni a Testük és Lelkük .Szeretnénk kiállni értük és képviselni Őket.Támaszt nyújtani bármilyen formában legyen az fizikális vagy szellemi.</p>
            <img className={styles['card-img-top']} src={aboutUsImage} alt="Fourth slide" />
          </div>
          <br />
          <div className={styles['container2']}>
            <h2>Küldetésünk </h2>
            <p>Küldetésünk minnél több állatot legyen szó kutyáról , macskáról!Segíteni ellátni .Gazdát keresni új lakhelyet találni befogadni akár 1 napra vagy teljes gondozásba venni .Minden állat egy lélek és ezzel nekünk is egy küldetés .Célünk továbbá a sérült állatok újra integrálása mind emberi közösségbe mind vissza a Természetbe.</p>
            <img className={styles['card-img-top']} src={missionImage} alt="Fourth slide" />
          </div>
        </section>
      </main>
      <footer>
        <div style={{ textAlign: 'center' }}> {/* Új div a gomb középre igazításához */}
          <button className="btn btn-secondary" type="button"  onClick={() => window.scrollTo(0, 0)}>Ugrás a lap tetejére</button>
        </div>
      </footer>
      <br />
    </div>
  );
}
//<img src={missionImage} alt="Mission" className="img-fluid" />
export default AboutPage;
