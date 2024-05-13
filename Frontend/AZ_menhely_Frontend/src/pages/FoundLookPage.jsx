import { Link } from 'react-router-dom';
import styles from '../styles/FoundLookPage.module.css';
import commonStyles from '../styles/CommonStyles.module.css';
import image1 from '../assets/front1.jpg';
import image2 from '../assets/front4.jpg';

function FoundLookPage() {
  return (
    <div className="row justify-content-center">
      <div className="col-lg-5 col-md-8 col-sm-12 mb-4">
        <h2 className="my-4 ">Talált állatok</h2>
        <Link to="/look-for">
          <div className={styles.card}>
            <img className={commonStyles['card-img-top']} src={image1} alt="Talált állatok" />
          </div>
        </Link>
      </div>
      <div className="col-lg-5 col-md-8 col-sm-12 mb-4">
        <h2 className="my-4 ">Elveszett állatok</h2>
        <Link to="/found">
          <div className={styles.card}>
            <img className={commonStyles['card-img-top']} src={image2} alt="Elveszett állatok" />
          </div>
        </Link>
      </div>
    </div>
  );
}

export default FoundLookPage;