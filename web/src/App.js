import React from "react";
import Header from "./components/Header";
import Footer from "./components/Footer";
import "./App.css";
import Routes from "./routes";

function App() {
  return (
    <>
      <Header />
      <div className="container">
        <Routes />
      </div>
      <Footer />
    </>
  );
}

export default App;
