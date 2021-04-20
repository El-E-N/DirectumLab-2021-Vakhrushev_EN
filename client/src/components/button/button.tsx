import * as React from 'react';

interface IButton {
  className?: string;
  value: any;
}

const Button: React.FunctionComponent<IButton> = (props) => {
  return <button className={props.className || ''}>{props.value}</button>;
};

export default Button;
