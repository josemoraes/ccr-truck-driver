import React from "react";
import { AiOutlineWoman, AiOutlineWarning } from "react-icons/ai";
import { GiRobberMask } from "react-icons/gi";
import { FaClinicMedical } from "react-icons/fa";
import { RiRoadMapLine, RiToolsLine, RiAlarmWarningLine } from "react-icons/ri";
import "./styles.css";

function Card({
  title,
  date,
  alertCode,
  driver,
  isActive = false,
  onClickSupportButton,
}) {
  const ALERT_CODE_HEALTH = 1;
  const ALERT_CODE_ROBBERY = 2;
  const ALERT_CODE_ACCIDENT = 3;
  const ALERT_CODE_MECHANICAL = 4;
  const ALERT_CODE_HARASSMENT = 5;
  const ALERT_CODE_ROBBERY_SUSPECT = 6;

  return (
    <div className={`card ${isActive && "active"}`}>
      <div className="card-avatar">
        {alertCode === ALERT_CODE_HEALTH && <FaClinicMedical size={30} />}
        {alertCode === ALERT_CODE_ROBBERY && <GiRobberMask size={30} />}
        {alertCode === ALERT_CODE_ACCIDENT && <RiAlarmWarningLine size={30} />}
        {alertCode === ALERT_CODE_MECHANICAL && <RiToolsLine size={30} />}
        {alertCode === ALERT_CODE_HARASSMENT && <AiOutlineWoman size={30} />}
        {alertCode === ALERT_CODE_ROBBERY_SUSPECT && (
          <AiOutlineWarning size={30} />
        )}
      </div>
      <div className="card-content">
        <div className="card-header">
          <strong>{title}</strong>
          <span className="occurrence-date">
            <strong>ocorrência registrada em:</strong> {date}
          </span>
        </div>
        <div className="card-body">
          <div className="flex-row">
            <p>
              <strong>Nome do motorista</strong>
              <br />
              <span>{driver.name}</span>
            </p>
            <p>
              <strong>Veículo</strong>
              <br />
              <span>{driver.plate}</span>
            </p>
            <p>
              <strong>Telefone</strong>
              <br />
              <span>{driver.phone}</span>
            </p>
          </div>
          <div className="flex-row">
            <p>
              <strong>Localização aproximada do motorista</strong>
              <br />
              <span>Rodovia Miguel Jubran, KM 55</span>
            </p>
            <button
              type="button"
              className="btn"
              onClick={onClickSupportButton}
            >
              <RiRoadMapLine />
              Pontos de apoio próximos
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Card;
