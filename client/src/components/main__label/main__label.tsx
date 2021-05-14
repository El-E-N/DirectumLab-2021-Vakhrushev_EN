import * as React from 'react';
import Input from '../input/input';
import './main__label.css';

interface IProps {
  updateValue?(evt: React.ChangeEvent<HTMLInputElement>): void;
  title: string;
  placeHolder: string;
  name: string;
  id?: string;
}

class MainLabel extends React.Component<IProps, unknown> {
  render() {
    return <label className="main__label">
      {this.props.title}
      <Input
        onBlur={(evt) => this.props.updateValue && this.props.updateValue(evt)}
        id={this.props.id}
        className={'main__input'}
        type={'text'}
        name={this.props.name}
        placeHolder={this.props.placeHolder}
      />
    </label>;
  }
}

export default MainLabel;
