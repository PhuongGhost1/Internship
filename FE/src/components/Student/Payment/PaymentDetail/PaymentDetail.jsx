import React, { useState } from 'react';
import './PaymentDetail.css';

const PaymentDetail = () => {
    const [paymentMethod, setPaymentMethod] = useState('VISA');
    const [cardNumber, setCardNumber] = useState('');
    const [expiryDate, setExpiryDate] = useState('');
    const [cvc, setCvc] = useState('');
    const [cardholderName, setCardholderName] = useState('');
    const [saveCard, setSaveCard] = useState(true);

    const handleSubmit = (e) => {
        e.preventDefault();
        if (validateForm()) {
            alert("Card added successfully!");
            console.log({ paymentMethod, cardNumber, expiryDate, cvc, cardholderName, saveCard });
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
        return true;
    };

    return (
        <div className="form-container">
            <div className="add-new-card">
                <h2>Add new card</h2>
                <div className="paymentOptions">
                    <label>
                        <input
                            type="radio"
                            name="paymentMethod"
                            value="VISA"
                            checked={paymentMethod === 'VISA'}
                            onChange={() => setPaymentMethod('VISA')}
                        />
                        VISA
                    </label>
                    <label>
                        <input
                            type="radio"
                            name="paymentMethod"
                            value="PAYPAL"
                            checked={paymentMethod === 'PAYPAL'}
                            onChange={() => setPaymentMethod('PAYPAL')}
                        />
                        PAYPAL
                    </label>
                </div>
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="cardNumber">Card number</label>
                        <input
                            type="text"
                            id="cardNumber"
                            value={cardNumber}
                            onChange={(e) => setCardNumber(e.target.value)}
                            placeholder="0000 0000 0000 0000"
                        />
                    </div>
                    <div className="form-row">
                        <div className="form-group">
                            <label htmlFor="expiryDate">Expiry date</label>
                            <input
                                type="text"
                                id="expiryDate"
                                value={expiryDate}
                                onChange={(e) => setExpiryDate(e.target.value)}
                                placeholder="MM / YY"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="cvc">CVC/CVV</label>
                            <input
                                type="text"
                                id="cvc"
                                value={cvc}
                                onChange={(e) => setCvc(e.target.value)}
                                placeholder="CVV"
                            />
                        </div>
                    </div>
                    <div className="form-group">
                        <label htmlFor="cardholderName">Cardholder name</label>
                        <input
                            type="text"
                            id="cardholderName"
                            value={cardholderName}
                            onChange={(e) => setCardholderName(e.target.value)}
                            placeholder="Enter cardholder's full name"
                        />
                    </div>
                    <div className="form-group checkbox">
                        <input
                            type="checkbox"
                            id="saveCard"
                            checked={saveCard}
                            onChange={(e) => setSaveCard(e.target.checked)}
                        />
                        <label htmlFor="saveCard">Save card</label>
                    </div>
                    <button type="submit" className="submit-button">Add card</button>
                </form>
            </div>
        </div>
    );
};

export default PaymentDetail;
