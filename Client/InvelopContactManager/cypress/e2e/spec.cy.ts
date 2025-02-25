describe('Create New Contact', () => {
  it('should create a new contact successfully', () => {
    cy.visit('http://localhost:4200/contacts-editor', { timeout: 10000 });

    cy.get('input#firstName').type('Test1');
   
    cy.get('input#surname').click();
    cy.get('input#address').click();
    cy.get('input#iban').click();
    cy.get('input#phoneNumber').click();

    cy.get('body').click();

    cy.contains('Surname is required').should('be.visible');;
    cy.contains('Address is required').should('be.visible');;
    cy.contains('IBAN is required').should('be.visible');;
    cy.contains('Phone Number is required').should('be.visible');;
  });
});