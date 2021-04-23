import * as React from 'react';
import MainLabel from '../main__label/main__label';
import Button from '../button/button';
import './main.css';

export interface IArrayElement {
  label: string;
  placeHolder: string;
  name: string;
}

interface IProps {
  mainTitle: string;
  className?: string;
  values: Array<IArrayElement>;
}

const Main: React.FunctionComponent<IProps> = (props) => {
  const className = `main__content ${props.className}`;

  return <main className="main">
    <div className={className}>
      <span className="main__tagline">{'Let\'s start!'}</span>
      <h2 className="main__title">{props.mainTitle}</h2>
      {props.values.map((array) => {
        return <MainLabel key={array.name} name={array.name} title={array.label} placeHolder={array.placeHolder} />;
      })}
      <Button className={'main__button'} value={'Enter'}/>
    </div>
  </main>;
};

export default Main;
