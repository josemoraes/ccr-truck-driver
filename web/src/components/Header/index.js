import React from "react";
import "./styles.css";
import logo from "../../assets/img/logo.png";

function Header() {
  return (
    <header>
      <div className="left-content">
        <img src={logo} alt="RodAPI" />
      </div>
      <div className="right-content">
        <ul>
          <li>
            <a
              href="https://github.com/josemoraes/ccr-truck-driver"
              target="_blank"
              rel="noopener noreferrer"
            >
              Github
            </a>
          </li>
        </ul>
      </div>
    </header>
  );
}

export default Header;
