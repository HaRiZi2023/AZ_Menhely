import { Link } from 'react-router-dom';
import styles from '../styles/FoundLookPage.module.css';
import image1 from '../assets/front1.jpg';
import image2 from '../assets/front4.jpg';

function FoundLookPage() {
  return (
    <div className="row justify-content-center" style={{ padding: '45px' }}>
      <div className="col-lg-5 col-md-8 col-sm-12 mb-4">
        <h2 className="my-2 ">Talált állatok</h2>
        <Link to="/look-for">
          <div className={styles.card}>
            <img className={styles['card-img-top']} src={image1} alt="Fourth slide" />
          </div>
        </Link>
      </div>
      <div className="col-lg-5 col-md-8 col-sm-12 mb-4">
        <h2 className="my-2 ">Elveszett állatok</h2>
        <Link to="/found">
          <div className={styles.card}>
            <img className={styles['card-img-top']} src={image2} alt="Fourth slide" />
          </div>
        </Link>
      </div>
    </div>
  );
}

export default FoundLookPage;