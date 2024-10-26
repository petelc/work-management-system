import Divider from '@mui/material/Divider';
import Hero from '../../components/hero/Hero';
import Features from '../../components/features/Features';
import FAQ from '../../components/faq/FAQ';
import Footer from '../../components/footer/Footer';

function HomePage() {
  return (
    <>
      <Hero />
      <div>
        <Features />
        <Divider />
        <FAQ />
        <Divider />
        <Footer />
      </div>
    </>
  );
}

export default HomePage;
