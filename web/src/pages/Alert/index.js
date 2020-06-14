import React, { useState, useEffect } from "react";
import "./styles.css";
import Card from "../../components/Card";
import { Map, TileLayer, Marker, Popup } from "react-leaflet";
import { FiSearch } from "react-icons/fi";
import * as apiConfig from "../../config/api";

function Alert() {
  const [alerts, setAlerts] = useState([]);
  const [supportPoints, setSupportPoints] = useState([]);
  const [selectedAlertId, setSelectedAlertId] = useState("");
  const [searchTerm, setSearchTerm] = useState("");
  const [isLoadingAlerts, setIsLoadingAlerts] = useState(true);
  const [centerPositionOfMap, setCenterPositionOfMap] = useState({
    latitude: -23.3211063,
    longitude: -51.2358039,
  });

  useEffect(() => {
    async function bootstrap() {
      const data = await fetchAlerts();
      setAlerts(data);
      setIsLoadingAlerts(false);
    }
    bootstrap();
  }, []);

  async function fetchAlerts() {
    const response = await fetch(`${apiConfig.baseUrl}/alerts`);
    const alertsToReturn = await response.json();
    return alertsToReturn;
  }

  async function handleSubmitSearch(event) {
    event.preventDefault();
    setIsLoadingAlerts(true);
    const data = await fetchAlerts();
    setAlerts(data.filter((alert) => alert.driver.name.includes(searchTerm)));
    setIsLoadingAlerts(false);
  }

  async function handleClickSupportButton(alert_id) {
    setSelectedAlertId(alert_id);
    const { alert_code } = alerts.filter((alert) => alert.id === alert_id)[0];
    const response = await fetch(
      `${apiConfig.baseUrl}/support-points?alert_codes_that_attends=${alert_code}`
    );
    const supportPointsReturned = await response.json();
    if (supportPointsReturned.length > 0) {
      const { latitude, longitude } = supportPointsReturned[0];
      setCenterPositionOfMap({ latitude, longitude });
    }
    setSupportPoints(supportPointsReturned);
  }

  return (
    <div className="flex-row">
      <div className="alerts">
        <form className="search" onSubmit={handleSubmitSearch}>
          <input
            type="search"
            className="searchTerm"
            placeholder="Pesquise pelo nome do motorista"
            onChange={(e) => setSearchTerm(e.target.value)}
          />
          <button type="submit" className="searchButton">
            <FiSearch />
          </button>
        </form>
        {isLoadingAlerts ? (
          <div className="lds-facebook">
            <div></div>
            <div></div>
            <div></div>
          </div>
        ) : (
          alerts.map((alert) => (
            <Card
              title={alert.title}
              date={alert.date}
              alert_code={alert.alert_code}
              driver={alert.driver}
              alertCode={alert.alert_code}
              key={alert.id}
              isActive={alert.id === selectedAlertId}
              onClickSupportButton={() => handleClickSupportButton(alert.id)}
            />
          ))
        )}
        {!alerts.length && !isLoadingAlerts && (
          <blockquote>Alertas não encontrados</blockquote>
        )}
      </div>
      <div className="map">
        <Map
          center={[centerPositionOfMap.latitude, centerPositionOfMap.longitude]}
          zoom={13}
        >
          <TileLayer
            attribution='&amp;copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          />
          {supportPoints.map((supportPoint) => (
            <Marker
              position={[supportPoint.latitude, supportPoint.longitude]}
              key={supportPoint.id}
            >
              <Popup>
                <strong>{supportPoint.name}</strong> <br />
                {supportPoint.phone}
              </Popup>
            </Marker>
          ))}
        </Map>
      </div>
    </div>
  );
}

export default Alert;
