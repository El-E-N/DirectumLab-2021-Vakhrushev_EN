import * as React from 'react';
import AverageValues from '../average-values/average-values';
import Input from '../input/input';
import './main__label.css';

interface IProps {
  updateValue(evt: React.ChangeEvent<HTMLInputElement>): void;
  title: string;
  placeHolder: string;
  name: string;
  id?: string;
  class?: string;
}

class MainLabel extends React.Component<IProps, unknown> {
  render() {
    return <label className={'main__label ' + this.props.class}>
      {this.props.title}
      <Input
        onBlur={this.props.updateValue}
        id={this.props.id}
        className={'main__input '}
        type={'text'}
        name={this.props.name}
        placeHolder={this.props.placeHolder}
      />
    </label>;
  }
}

export default MainLabel;
