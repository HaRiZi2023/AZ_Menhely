import React from 'react';
import { Carousel } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import image1 from '../assets/istockphoto-1337866980-612x612.jpg';
import image2 from '../assets/istockphoto-1468289341-612x612.jpg';
import image3 from '../assets/pexels-vishnu-pv-12766880.jpg';
import image4 from '../assets/istockphoto-1481344935-612x612.jpg';
import aboutUsImage from '../assets/istockphoto-918369208-612x612.jpg';
import missionImage from '../assets/istockphoto-872833826-612x612.jpg'

function AboutPage() {
  return (
    <div className="AboutPage">
      <header className="AboutPage-header">
        <Carousel >
          <Carousel.Item>
            <img
              className="d-block w-100"
              src={image1}
              alt="First slide"
            />
          </Carousel.Item>
          <Carousel.Item>
            <img
              className="d-block w-100"
              src={image2}
              alt="Second slide"
            />
          </Carousel.Item>
          <Carousel.Item>
            <img
              className="d-block w-100"
              src={image3}
              alt="Third slide"
            />
          </Carousel.Item>
          <Carousel.Item>
            <img
              className="d-block w-100"
              src={image4}
              alt="Fourth slide"
            />
          </Carousel.Item>
        </Carousel>
        <section className="py-5">
        <div className="container2">
            <h1>Azért jöttünk létre . . .</h1>
            <p>Szeretnénk minnél több állaton segíteni!Őket is úgyan olyan jogok illetik meg ,csak mert nem tudnak beszélni ŐK is éreznek.Sajnos az emberek elfelejtik hogy az állatoknak is vannak érzéseik és nekik is tud fájni a Testük és Lelkük .Szeretnénk kiállni értük és képviselni Őket.Támaszt nyújtani bármilyen formában legyen az fizikális vagy szellemi.</p>
            <img src={aboutUsImage} alt="About us" className="img-fluid" />
        </div>
        <div className="container2">
            <h1>Küldetésünk </h1>
            <p>Küldetésünk minnél több állatot legyen szó kutyáról , macskáról!Segíteni ellátni .Gazdát keresni új lakhelyet találni befogadni akár 1 napra vagy teljes gondozásba venni .Minden állat egy lélek és ezzel nekünk is egy küldetés .Célünk továbbá a sérült állatok újra integrálása mind emberi közösségbe mind vissza a Természetbe.</p>
            <img src={missionImage} alt="Mission" className="img-fluid" />
        </div>
        </section>
      </header>
    </div>
  );
}

export default AboutPage;
