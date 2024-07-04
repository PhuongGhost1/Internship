import React, { useEffect, useState } from 'react';
import './PaymentDetail.css';
import Cards from 'react-credit-cards';
import 'react-credit-cards/es/styles-compiled.css';
import { BsCreditCardFill } from "react-icons/bs";
import { TbBrandPaypalFilled } from "react-icons/tb";

const PaymentDetail = () => {
    const [paymentMethod, setPaymentMethod] = useState('VISA');
    const [cardNumber, setCardNumber] = useState('');
    const [expiryDate, setExpiryDate] = useState('');
    const [cvc, setCvc] = useState('');
    const [cardholderName, setCardholderName] = useState('');
    const [saveCard, setSaveCard] = useState(true);
    const [focus, setFocus] = useState('');
    const [walletAmount, setWalletAmount] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        if (validateForm()) {
            alert("Card added successfully!");
            console.log({ paymentMethod, cardNumber, expiryDate, cvc, cardholderName, saveCard });
        }
    };

    const handleWalletSubmit = (e) => {
        e.preventDefault();
        if (validateWalletForm()) {
            alert("Amount added to wallet successfully!");
            console.log({ walletAmount });
        }
    };

    const handleInputFocus = (e) => {
        setFocus(e.target.name);
    };

    const handleExpiryDateChange = (e) => {
        let value = e.target.value.replace(/\s/g, '');
        if (value.length <= 5) {
            if (value.length === 2 && !value.includes('/')) {
                const month = parseInt(value, 10);
                if (month > 0 && month <= 12) {
                    value = value + ' / ';
                } else {
                    alert("Invalid month. Please enter a month between 01 and 12.");
                    return;
                }
            }
            setExpiryDate(value);
        } else {
            setExpiryDate(value.slice(0, 5));
        }
    };

    const validateForm = () => {
        if (cardholderName.length < 10) {
            alert("Cardholder name must be at least 10 characters long.");
            return false;
        }
        if (!/^\d+$/.test(cardNumber)) {
            alert("Card number must only contain digits.");
            return false;
        }
        if (!/^\d{3,4}$/.test(cvc)) {
            alert("CVV must be 3 to 4 digits long.");
            return false;
        }
        if (!/^\d{2}\s\/\s\d{2}$/.test(expiryDate)) {
            alert("Expiry date format is invalid. Please use MM / YY.");
            return false;
        }
        return true;
    };

    useEffect(() => {
        console.log(cvc);
    }, [cvc]);

    return (
        <div id="form-container">
            <div className="add-new-card">
                <div className="form-contain">
                    <div>
                        <label htmlFor="payment-method" className="form-title">Payment Method</label>
                        <div className="paymentOptions">
                            <input
                                type="radio"
                                name="paymentMethod"
                                id="visa"
                                value="VISA"
                                checked={paymentMethod === 'VISA'}
                                onChange={() => setPaymentMethod('VISA')}
                            />
                            <label htmlFor="visa">
                                <BsCreditCardFill />
                                Debit/Credit Card
                            </label>
                            <input
                                type="radio"
                                name="paymentMethod"
                                id="paypal"
                                value="PAYPAL"
                                checked={paymentMethod === 'PAYPAL'}
                                onChange={() => setPaymentMethod('PAYPAL')}
                            />
                            <label htmlFor="paypal">
                                <TbBrandPaypalFilled />
                                &nbsp;&nbsp;PAYPAL
                            </label>
                        </div>
                        <form onSubmit={handleSubmit}>
                            <div className="form-fields">
                                {paymentMethod === 'VISA' && (
                                    <>
                                        <div className="form-group">
                                            <label htmlFor="cardNumber" className="form-title">Card number</label>
                                            <input
                                                type="text"
                                                name="cardNumber"
                                                value={cardNumber}
                                                onChange={(e) => setCardNumber(e.target.value)}
                                                placeholder="0000 0000 0000 0000"
                                                onFocus={handleInputFocus}
                                            />
                                        </div>
                                        <div className="form-row">
                                            <div className="form-group">
                                                <label htmlFor="expiryDate" className="form-title">Expiry date</label>
                                                <input
                                                    type="text"
                                                    name="expiryDate"
                                                    value={expiryDate}
                                                    onChange={handleExpiryDateChange}
                                                    placeholder="MM / YY"
                                                    onFocus={handleInputFocus}
                                                />
                                            </div>
                                            <div className="form-group">
                                                <label htmlFor="cvc" className="form-title">CVC/CVV</label>
                                                <input
                                                    type="text"
                                                    name="cvc"
                                                    value={cvc}
                                                    onChange={(e) => setCvc(e.target.value)}
                                                    placeholder="CVV"
                                                    onFocus={handleInputFocus}
                                                />
                                            </div>
                                        </div>
                                        <div className="form-group holderName">
                                            <label htmlFor="cardholderName" className="form-title">Cardholder name</label>
                                            <input
                                                type="text"
                                                name="cardholderName"
                                                value={cardholderName}
                                                onChange={(e) => setCardholderName(e.target.value)}
                                                placeholder="Enter cardholder's full name"
                                                onFocus={handleInputFocus}
                                            />
                                        </div>
                                    </>
                                )}
                            </div>
                        </form>
                    </div>
                    {paymentMethod === 'VISA' && (
                        <div className="card-visa">
                            <Cards
                                cvc={cvc}
                                expiry={expiryDate}
                                focused={focus}
                                name={cardholderName}
                                number={cardNumber}
                            />
                            <form onSubmit={handleWalletSubmit}>
                                <div className="form-group addWallet">
                                    <label htmlFor="walletAmount" className="form-title">Add Money to Wallet</label>
                                    <input
                                        type="text"
                                        name="walletAmount"
                                        value={walletAmount}
                                        onChange={(e) => setWalletAmount(e.target.value)}
                                        placeholder="Enter amount"
                                    />
                                </div>
                            </form>
                        </div>
                    )}
                </div>
                <div className="button-contain">
                    <div className="add-wallet button">Add Wallet Now</div>
                    <div className="cancel button">Cancel And Return</div>
                </div>
            </div>
        </div>
    );
};

export default PaymentDetail;
